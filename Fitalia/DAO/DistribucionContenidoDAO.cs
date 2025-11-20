using Dapper;
using Fitalia.Entities;
using Fitalia.Interfaces;
using Fitalia.Queries;
using Fitalia.Utilities; // Asumiendo que SQLServerConfiguration está aquí
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Fitalia.DAO
{
    // Hereda de la nueva interfaz
    public class DistribucionContenidoDAO : IDistribucionContenidoDAO
    {
        private readonly SQLServerConfiguration _connectionString;
        private readonly ILogger<DistribucionContenidoDAO> _logger;

        public DistribucionContenidoDAO(IOptions<SQLServerConfiguration> connectionString, ILogger<DistribucionContenidoDAO> logger)
        {
            _connectionString = connectionString.Value;
            _logger = logger;
        }

        protected SqlConnection Connection()
        {
            return new SqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<ContenidoBienestar>> ObtenerContenidoPorAnimo(int typeAnimoId)
        {
            try
            {
                using var db = Connection();

                var content = await db.QueryAsync<ContenidoBienestar>(
                    DistribucionContenidoQueries.ObtenerContenidoPorAnimo,
                    new { TypeAnimoId = typeAnimoId }
                );

                // ¡Agrega una validación para ver si el mapeo falló!
                if (content == null || !content.Any())
                {
                    _logger.LogWarning($"DAO NO ENCONTRÓ NADA O FALLÓ EL MAPEO para ID: {typeAnimoId}");
                }
                return content;
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Falló: {ex}");
            }
            return null;
        }
    }
}