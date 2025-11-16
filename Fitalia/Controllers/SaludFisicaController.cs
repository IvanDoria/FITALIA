using Fitalia.Entities;
using Fitalia.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fitalia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaludFisicaController : ControllerBase
    {
        private readonly ISaludFisica repo;

        public SaludFisicaController(ISaludFisica repo)
        {
            this.repo = repo;
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] SaludFisica actividad)
        {
            actividad.Fecha = DateTime.Now;

            var ok = await repo.Insertar(actividad);
            return ok ? Ok("Registro guardado") : BadRequest("Error al guardar");
        }


        [HttpGet("Historial/{userId}")]
        public async Task<IActionResult> Historial(int userId)
        {
            var datos = await repo.ListarPorUsuario(userId);
            return Ok(datos);
        }
    }
}

