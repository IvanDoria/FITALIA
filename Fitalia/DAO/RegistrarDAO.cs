using Dapper;
using Fitalia.Entities;
using Fitalia.Interfaces;
using Fitalia.Queries;
using Fitalia.Utilities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

namespace Fitalia.DAO
{
    public class RegistrarDAO:IRegistrarDAO
    {

        private readonly SQLServerConfiguration _connectionString;
        private readonly ILogger<RegistrarDAO> _logger;

        public RegistrarDAO()
        {

        }

        public RegistrarDAO(IOptions<SQLServerConfiguration> connectionString, ILogger<RegistrarDAO> logger)
        {
            _connectionString = connectionString.Value;
            _logger = logger;
        }

        protected SqlConnection Connection()
        {
            return new SqlConnection(_connectionString.ConnectionString);
        }

        public async Task<string> Registrar(Usuario usuario)
        {
            try
            {
                using var db = Connection();
                var parameters = new DynamicParameters();

                parameters.Add("@nombreInsertado", usuario.nombre);
                parameters.Add("@apellidoPaternoInsertado", usuario.apellidoPaterno);
                parameters.Add("@apellidoMaternoInsertado", usuario.apellidoMaterno);
                parameters.Add("@edadInsertado", usuario.edad);
                parameters.Add("@numeroDeTelefonoInsertado", usuario.numeroDeTelefono);
                parameters.Add("@sexoInsertado", usuario.sexo);
                parameters.Add("@NombreUsuarioInsertado", usuario.NombreUsuario);
                parameters.Add("@CorreoInsertado", usuario.Correo);
                parameters.Add("@ContraseñaInsertado", usuario.Contraseña);
                parameters.Add("@TypeUserInsertado", 1);
                parameters.Add("@Mensaje", dbType: DbType.String, size: 100, direction: ParameterDirection.Output);

                await db.ExecuteAsync("InsertarDatosPersonaUsuario", parameters, commandType: CommandType.StoredProcedure);

                string mensaje = parameters.Get<string>("@Mensaje");

                _logger.LogInformation($"Resultado del registro: {mensaje}");
                return mensaje;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al insertar en SQL Server: {ex.Message}");
                return $"Error: {ex.Message}";
            }
        }


        public async Task<string> BuscarCorreo(string correo)
        {
            try
            {
                using var db = Connection();
                var result = await db.QueryFirstOrDefaultAsync<string>(RegistrarQueries.buscarCorreo, new { Correo = correo });
                _logger.LogInformation("Consulta exitosa de usuario en SQL Server");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error, no se a podido verificar los datos del usuario: {ex.Message}");
                Console.WriteLine($"Error SQL Server: {ex.Message}");
            }
            return null ;
        }



    }
}
