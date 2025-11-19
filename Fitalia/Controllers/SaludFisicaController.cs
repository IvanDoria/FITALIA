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
            var id = await service.RegistrarActividad(actividad);

            if (id > 0)
                return Ok(new { success = true, id });

            return BadRequest(new { success = false, message = "Error al guardar" });
        }


        [HttpGet("Historial/{userId}")]
        public async Task<IActionResult> Historial(int userId)
        {
            var datos = await service.ObtenerHistorial(userId);
            return Ok(datos);
        }

        [HttpPut("Editar/{id}")]
        public async Task<IActionResult> Editar(int id, [FromBody] SaludFisica actividad)
        {
            var ok = await service.EditarActividad(id, actividad);
            return ok ? Ok("Actividad editada") : BadRequest("No se pudo editar");
        }

        [HttpPut("Cumplido/{id}")]
        public async Task<IActionResult> MarcarCumplido(int id)
        {
            var ok = await service.MarcarComoCumplido(id);
            return ok ? Ok("Marcado como cumplido") : BadRequest("No se pudo marcar");
        }

        [HttpDelete("Eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var ok = await service.EliminarActividad(id);
            return ok ? Ok("Eliminado correctamente") : BadRequest("No se pudo eliminar");
        }


    }
}



