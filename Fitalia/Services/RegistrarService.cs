using Fitalia.DAO;
using Fitalia.Entities;
using Fitalia.Interfaces;

namespace Fitalia.Services
{
    public class RegistrarService:IRegistrarService
    {
        private readonly IRegistrarDAO _registrarDAO;
        private readonly ILogger<RegistrarService> _logger;

        public RegistrarService(IRegistrarDAO registrarDAO, ILogger<RegistrarService> logger)
        {
            _registrarDAO = registrarDAO;
            _logger = logger;
        }

        public async Task<Boolean> RegistrarUsuario(Persona person, Usuario user)
        {

            return await _registrarDAO.Registrar(new List<string>());
        }

    }
}
