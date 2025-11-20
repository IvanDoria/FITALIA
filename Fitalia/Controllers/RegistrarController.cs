using Microsoft.AspNetCore.Mvc;
using Fitalia.Entities;
using Fitalia.Interfaces;

namespace Fitalia.Controllers
{
    [ApiController]
    [Route("API/Registrar")]
    public class RegistrarController: ControllerBase
    {
        private readonly IRegistrarService _RegistrarService;
        private readonly ILogger<RegistrarController> _logger;

        public RegistrarController(IRegistrarService RegistrarService, ILogger<RegistrarController> logger)
        {
            _RegistrarService = RegistrarService;
            _logger = logger;
        }

        [HttpPost]
        [Route("RegistrarUsuario")]
        public async Task<IActionResult> CreateUser(Usuario user)
        {
            var respuesta = await _RegistrarService.RegistrarUsuario(user);
            return respuesta.Equals("Registro realizado correctamente") ? Ok(new { mensaje = respuesta }) : BadRequest(new { mensaje = respuesta });
        }
    }
}
