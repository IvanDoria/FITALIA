using Fitalia.Entities;
using Fitalia.Interfaces;
using Microsoft.Extensions.Logging;
using System.Net.WebSockets;

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

            if (!((int)estado.TipoDeAnimo > 0 && (int)estado.TipoDeAnimo < 6))
            {
                return false;
            }

            var result = await _EstadoDeAnimoDAO.guardarEstadoDeAnimo(estado); ;
            _logger.LogInformation("estado: " + result);
            return result;
            
        }

        public async Task<EstadoDeAnimo> getEstado(string userId, string fecha)
        {
            var response = await _EstadoDeAnimoDAO.obtenerEstado(userId, fecha);
            if (response == null) {
                _logger.LogInformation("No se pudo encontrar un estado de animo");
            }
             return response;
        }
    }
}
