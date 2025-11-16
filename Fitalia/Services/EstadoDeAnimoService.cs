using Fitalia.Entities;
using Fitalia.Interfaces;
using Microsoft.Extensions.Logging;

namespace Fitalia.Services
{
    public class EstadoDeAnimoService:IEstadoDeAnimoService
    {
        private readonly IEstadoDeAnimoDAO _EstadoDeAnimoDAO;
        private readonly ILogger<EstadoDeAnimoService> _logger;

        public EstadoDeAnimoService(IEstadoDeAnimoDAO EstadoDeAnimoDAO, ILogger<EstadoDeAnimoService> logger)
        {
            _EstadoDeAnimoDAO = EstadoDeAnimoDAO;
            _logger = logger;
        }
        public async Task<bool> guardarEstado(EstadoDeAnimo estado)
        {

            if (!((int)estado.Estado > 0 && (int)estado.Estado < 6))
            {
                return false;
            }

            var result = await _EstadoDeAnimoDAO.guardarEstadoDeAnimo(estado); ;
            _logger.LogInformation("estado: " + result);
            return result;
            
        }

        public async Task<string> getEstado(string userId)
        {
            return await _EstadoDeAnimoDAO.obtenerEstado(userId);
        }
    }
}
