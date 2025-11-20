using Fitalia.Entities;
using Fitalia.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class RecordatoriosController : ControllerBase
{
    private readonly IRecordatoriosService service;

    public RecordatoriosController(IRecordatoriosService service)
    {
        this.service = service;
    }

    [HttpGet("PorHabito/{saludFisicaId}")]
    public async Task<IActionResult> GetByHabito(int saludFisicaId)
    {
        var r = await service.GetBySaludFisica(saludFisicaId);
        return Ok(r);
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var recordatorio = await service.GetById(id);

        if (recordatorio == null)
            return NotFound("Recordatorio no encontrado");

        return Ok(recordatorio);
    }


    [HttpPost("Crear")]
    public async Task<IActionResult> Crear([FromBody] Recordatorio model)
    {
        var id = await service.Create(model);
        return Ok(new { success = true, id });
    }

    [HttpPut("Editar/{id}")]
    public async Task<IActionResult> Editar(int id, [FromBody] Recordatorio model)
    {
        var actualizado = await service.Update(id, model);

        if (!actualizado)
            return NotFound("No se encontró el recordatorio");

        return Ok("Actualizado correctamente");
    }

    [HttpDelete("Eliminar/{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        await service.Delete(id);
        return Ok("Eliminado");
    }
}






