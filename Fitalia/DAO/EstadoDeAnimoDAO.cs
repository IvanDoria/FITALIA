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

        public async Task<EstadoDeAnimo> obtenerEstado(string userId, string fecha)
        {
            try
            {
                using var db = Connection();

                // 1. Convertir la fecha string (ej: "2025-11-19") a DateTime
                // Es crucial para que Dapper la envíe como un tipo de fecha correcto.
                if (!DateTime.TryParse(fecha, out DateTime fechaAComparar))
                {
                    _logger.LogError("Formato de fecha inválido.");
                    return null;
                }

                // 2. Definir el objeto de parámetros. 
                // ¡Los nombres deben coincidir exactamente con las variables de la consulta SQL!
                var parameters = new
                {
                    // La consulta SQL espera @UserId
                    UserId = userId,
                    // La consulta SQL espera @FechaAComparar
                    FechaAComparar = fechaAComparar
                };

                var resultadoRow = await db.QueryFirstOrDefaultAsync<EstadoDeAnimo>(
                    EstadoDeAnimoQueries.obtenerEstadoHoy, // Tu consulta estática (ej: SELECT ... WHERE UserId = @UserId AND Fecha = @FechaAComparar)
                    parameters // Pasamos el objeto con los parámetros correctos
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
