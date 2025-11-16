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
    public class EstadoDeAnimoDAO: IEstadoDeAnimoDAO
    {
        private readonly SQLServerConfiguration _connectionString;
        private readonly ILogger<EstadoDeAnimoDAO> _logger;

        public EstadoDeAnimoDAO(IOptions<SQLServerConfiguration> connectionString, ILogger<EstadoDeAnimoDAO> logger)
        {
            _connectionString = connectionString.Value;
            _logger = logger;
        }

        protected SqlConnection Connection()
        {
            return new SqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> guardarEstadoDeAnimo(EstadoDeAnimo estadoDeAnimo)
        {
            try
            {
                using var db = Connection();
                var result = await db.ExecuteAsync(EstadoDeAnimoQueries.guardarEstadoDeAnimo, new
                {
                    TypeEstadoAnimo = estadoDeAnimo.Estado,
                    UserIdDao = estadoDeAnimo.UserId,
                });
                _logger.LogInformation("Consulta exitosa de usuario en SQL Server");

                return result>0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error, no se a podido verificar los datos del usuario: {ex.Message}");
                Console.WriteLine($"Error SQL Server: {ex.Message}");
            }
            return false;
        }

        public async Task<string> obtenerEstado(string userId)
        {
            try
            {
                using var db = Connection();
                var parameters = new DynamicParameters();

                parameters.Add("@UserId", userId);

                parameters.Add("@fechaImport", DateTime.Now);

                parameters.Add("@Mensaje", dbType: DbType.String, size: 100, direction: ParameterDirection.Output);

                await db.ExecuteAsync("getEstadoDeAnimo", parameters, commandType: CommandType.StoredProcedure);
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
    }
}
