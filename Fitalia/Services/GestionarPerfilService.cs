using Fitalia.Interfaces;
using Fitalia.DAO;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Fitalia.Services
{
    public class GestionarPerfilService : IGestionarPerfilService
    {
        private readonly IGestionarPerfilDAO _gestionarPerfilDAO;
        private readonly ILogger<GestionarPerfilService> _logger;

        public GestionarPerfilService(IGestionarPerfilDAO gestionarPerfilDAO, ILogger<GestionarPerfilService> logger)
        {
            _gestionarPerfilDAO = gestionarPerfilDAO;
            _logger = logger;
        }

        public async Task<bool> CambiarApellidoPaterno(int userId, string apellidoPaterno)
        {
            if (string.IsNullOrWhiteSpace(apellidoPaterno))
            {
                _logger.LogWarning("El apellido paterno no puede estar vacío.");
                return false;
            }
            var result = await _gestionarPerfilDAO.actualizarApellidoPaterno(userId, apellidoPaterno);
            _logger.LogInformation($"Apellido paterno actualizado para userId {userId}: {result}");
            return result;
        }

        public async Task<bool> CambiarApellidoMaterno(int userId, string apellidoMaterno)
        {
            if (string.IsNullOrWhiteSpace(apellidoMaterno))
            {
                _logger.LogWarning("El apellido materno no puede estar vacío.");
                return false;
            }
            var result = await _gestionarPerfilDAO.actualizarApellidoMaterno(userId, apellidoMaterno);
            _logger.LogInformation($"Apellido materno actualizado para userId {userId}: {result}");
            return result;
        }

        public async Task<bool> CambiarCorreo(int userId, string correo)
        {
            if (string.IsNullOrWhiteSpace(correo))
            {
                _logger.LogWarning("El correo no puede estar vacío.");
                return false;
            }
            var result = await _gestionarPerfilDAO.actualizarCorreo(userId, correo);
            _logger.LogInformation($"Correo actualizado para userId {userId}: {result}");
            return result;
        }

        public async Task<bool> CambiarContrasena(int userId, string contrasena)
        {
            if (string.IsNullOrWhiteSpace(contrasena))
            {
                _logger.LogWarning("La contraseña no puede estar vacía.");
                return false;
            }
            var result = await _gestionarPerfilDAO.actualizarContrasena(userId, contrasena);
            _logger.LogInformation($"Contraseña actualizada para userId {userId}: {result}");
            return result;
        }
        public async Task<bool> CambiarFotoPerfil(int userId, string foto)
        {
            if (string.IsNullOrWhiteSpace(foto))
            {
                _logger.LogWarning("La foto de perfil no puede estar vacía.");
                return false;
            }

            var result = await _gestionarPerfilDAO.actualizarFotoPerfil(userId, foto);
            _logger.LogInformation($"Foto de perfil actualizada para userId {userId}: {result}");
            return result;
        }
        public async Task<bool> CambiarNombre(int userId, string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                _logger.LogWarning("El nombre no puede estar vacío.");
                return false;
            }
            var result = await _gestionarPerfilDAO.actualizarNombre(userId, nombre);
            _logger.LogInformation($"Nombre actualizado para userId {userId}: {result}");
            return result;
        }
        public async Task<bool> CambiarFechaNacimiento(int userId, string fechaNueva)
        {
            if (string.IsNullOrWhiteSpace(fechaNueva))
            {
                _logger.LogWarning("La fecha no puede estar vacía.");
                return false;
            }

            var result = await _gestionarPerfilDAO.actualizarFechaNacimiento(userId, fechaNueva);
            _logger.LogInformation($"la fecha actualizada para userId {userId}: {result}");
            return result;
        }
    }
}