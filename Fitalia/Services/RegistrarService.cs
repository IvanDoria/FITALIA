using Fitalia.DAO;
using Fitalia.Entities;
using Fitalia.Interfaces;
using Fitalia.Utilities;
using Fitalia.Enumerations;

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

        public async Task<string> RegistrarUsuario(Usuario usuario)
        {
            var existe = await _registrarDAO.BuscarCorreo(usuario.Correo);

            if (existe != null)
            {
                _logger.LogInformation("El correo ya existe.");
            }
            else
            {
                _logger.LogInformation("Correo disponible.");
            }

            usuario.NombreUsuario = CrearNombreUsuario.crearNombreUsuarioAleatorio(usuario.nombre, usuario.apellidoPaterno, usuario.apellidoMaterno);
            usuario.typeUser = TypeUser.Invitado;
            _logger.LogInformation(usuario.NombreUsuario);

            return await _registrarDAO.Registrar(usuario);
        }

    }
}
