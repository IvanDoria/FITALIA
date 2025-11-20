using Fitalia.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Fitalia.Entities;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Fitalia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GestionarPerfilController : ControllerBase
    {
        private readonly IGestionarPerfilService _perfilService;
        private readonly ILogger<GestionarPerfilController> _logger;

        public GestionarPerfilController(
            IGestionarPerfilService perfilService,
            ILogger<GestionarPerfilController> logger)
        {
            _perfilService = perfilService;
            _logger = logger;
        }

        [HttpPut]
        [Route("CambiarNombre")]
        public async Task<IActionResult> CambiarNombre(int userId, string nombre)
        {
            _logger.LogInformation("Usuario " + userId + " Nombre " + nombre);
            var result = await _perfilService.CambiarNombre(userId, nombre);
            return result ? Ok("Nombre actualizado correctamente") : BadRequest("No se pudo actualizar el nombre");
        }

        [HttpPut]
        [Route("CambiarApellidoPaterno")]
        public async Task<IActionResult> CambiarApellidoPaterno(int userId, string apellidoPaterno)
        {
            var result = await _perfilService.CambiarApellidoPaterno(userId, apellidoPaterno);
            return result ? Ok("Apellido paterno actualizado correctamente") : BadRequest("No se pudo actualizar el apellido paterno");
        }

        [HttpPut]
        [Route("CambiarApellidoMaterno")]
        public async Task<IActionResult> CambiarApellidoMaterno(int userId, string apellidoMaterno)
        {
            var result = await _perfilService.CambiarApellidoMaterno(userId, apellidoMaterno);
            return result ? Ok("Apellido materno actualizado correctamente") : BadRequest("No se pudo actualizar el apellido materno");
        }

        [HttpPut]
        [Route("CambiarCorreo")]
        public async Task<IActionResult> CambiarCorreo(int userId, string correo)
        {
            var result = await _perfilService.CambiarCorreo(userId, correo);
            return result ? Ok("Correo actualizado correctamente") : BadRequest("No se pudo actualizar el correo");
        }

        [HttpPut("CambiarFotoPerfil")]
        public async Task<IActionResult> CambiarFotoPerfil([FromBody] ActualizarFoto data)
        {
            // Validamos que llegue data
            if (data == null || string.IsNullOrWhiteSpace(data.FotoPerfil))
            {
                return BadRequest("La foto no puede estar vacía.");
            }

            // Usamos data.UserId y data.FotoPerfil que vienen del DTO
            var result = await _perfilService.CambiarFotoPerfil(data.UserId, data.FotoPerfil);

            return result ? Ok("Foto de perfil actualizada correctamente") : BadRequest("No se pudo actualizar la foto de perfil");
        }

        [HttpPut]
        [Route("CambiarFechaNacimiento")]
        public async Task<IActionResult> CambiarFechaNacimiento(int userId, string fechaNueva)
        {
            var result = await _perfilService.CambiarFechaNacimiento(userId, fechaNueva);
            return result ? Ok("Fecha de nacimiento actualizada correctamente") : BadRequest("No se pudo actualizar la fecha de nacimiento");
        }
    }
}
