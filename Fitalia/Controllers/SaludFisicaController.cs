using Fitalia.Entities;
using Fitalia.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fitalia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaludFisicaController : ControllerBase
    {
        private readonly ISaludFisicaService service;

        public SaludFisicaController(ISaludFisicaService service)
        {
            this.service = service;
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] SaludFisica actividad)
        {
            var ok = await service.RegistrarActividad(actividad);
            return ok ? Ok("Registro guardado") : BadRequest("Error al guardar");
        }

        [HttpGet("Historial/{userId}")]
        public async Task<IActionResult> Historial(int userId)
        {
            var datos = await service.ObtenerHistorial(userId);
            return Ok(datos);
        }
    }
}


