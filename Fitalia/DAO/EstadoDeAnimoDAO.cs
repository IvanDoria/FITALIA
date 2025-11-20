using Dapper;
using Fitalia.Entities;
using Fitalia.Interfaces;
using Fitalia.Queries;
using Fitalia.Utilities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;
using Fitalia.Enumerations;

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
                    TipoDeAnimo = (int)estadoDeAnimo.TipoDeAnimo,

                    UserIdDao = estadoDeAnimo.UserId,
                });

                _logger.LogInformation("Consulta exitosa de usuario en SQL Server");
                return result > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener estado de SQL Server: {ex.Message}");
                return false;
            }
        }

        public async Task<EstadoDeAnimo> obtenerEstado(string userId)
        {
            try
            {
                using var db = Connection();

                var resultadoRow = await db.QueryFirstOrDefaultAsync<EstadoDeAnimo>(
                    EstadoDeAnimoQueries.obtenerEstadoHoy,
                    new { UserId = userId }
                );

                
                return resultadoRow;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener estado de SQL Server: {ex.Message}");
                return null;
            }
        }
    }
}
