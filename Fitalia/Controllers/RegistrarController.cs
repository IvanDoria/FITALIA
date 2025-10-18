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

        //[HttpPost]
        //[Route("RegistrarUsuario")]
        //public async Task<IActionResult> CreateUser(Persona person,Usuario user)
        //{
            //return await _RegistrarService.RegistrarUsuario(person, user) ? Ok("Usuario creado") : BadRequest("No se pudo guardar el usuario.");
        //}
    }
}
