using Fitalia.Interfaces;

namespace Fitalia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class IniciarSesionController : ControllerBase
    {
        private readonly IIniciarSesionService _IniciarSesionService;
        private readonly ILogger<IniciarSesionController> _logger;

        public LoginController(IIniciarSesionService IniciarSesionService, ILogger<IniciarSesionController> logger)
        {
            _IniciarSesionService = IniciarSesionService;
            _logger = logger;
        }

        [HttpGet]
        [Route("VerificarUsuario")]
        public async Task<IActionResult> IniciarSesion(string userName, string password)
        {
            var user = await _IniciarSesionService.check(userName, password);
            return user != null ? Ok(user) : NotFound();
        }
    }
}
