using Fitalia.DAO;
using Fitalia.Entities;
using Fitalia.Interfaces;

namespace Fitalia.Services
{
    public class IniciarSesionService : IIniciarSesionService
    {
        private readonly IIniciarSesionDAO _IniciarSesionDAO;
        private readonly ILogger<IniciarSesionService> _logger;

        public IniciarSesionService(IIniciarSesionDAO IniciarSesionDAO)
        {
            _IniciarSesionDAO = IniciarSesionDAO;
        }
        public async Task<DatosUsuario> revisar(string userName, string password)
        {
            return await _IniciarSesionDAO.buscarUsuario(userName, password);
        }
    }
}
