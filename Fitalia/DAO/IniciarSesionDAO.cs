using Fitalia.Interfaces;
using Fitalia.Entities;
using Fitalia.Queries;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Fitalia.Utilities;

namespace Fitalia.DAO
{
    public class IniciarSesionDAO : IIniciarSesionDAO
    {
        private readonly SQLServerConfiguration _connectionString;
        private readonly ILogger<IniciarSesionDAO> _logger;

        public IniciarSesionDAO()
        {

        }

        public IniciarSesionDAO(IOptions<SQLServerConfiguration> connectionString, ILogger<IniciarSesionDAO> logger)
        {
            _connectionString = connectionString.Value;
            _logger = logger;
        }

        protected SqlConnection Connection()
        {
            return new SqlConnection(_connectionString.ConnectionString);
        }

        public async Task<Persona> buscarUsuario(string userName, string password)
        {
            try
            {
                using var db = Connection();
                var result = await db.QueryFirstOrDefaultAsync<Persona>(IniciarSesionQueries.buscarUsuario, new { UserName = userName, Password = password });
                _logger.LogInformation("Consulta exitosa de usuario en SQL Server");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error, no se a podido verificar los datos del usuario: {ex.Message}");
                Console.WriteLine($"Error SQL Server: {ex.Message}");
            }
            return null;
        }
    }
}
