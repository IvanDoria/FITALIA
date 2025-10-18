using Fitalia.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fitalia.Controllers
{
    [ApiController]
    [Route("API/IniciarSesion")]

    public class IniciarSesionController : ControllerBase
    {
        private readonly IIniciarSesionService _IniciarSesionService;
        private readonly ILogger<IniciarSesionController> _logger;

        public IniciarSesionController(IIniciarSesionService IniciarSesionService, ILogger<IniciarSesionController> logger)
        {
            _IniciarSesionService = IniciarSesionService;
            _logger = logger;
        }

        [HttpGet]
        [Route("VerificarUsuario")]
        public async Task<IActionResult> IniciarSesion(string userName, string password)
        {
            var user = await _IniciarSesionService.revisar(userName, password);
            return user != null ? Ok(user) : NotFound();
        }
    }
}
