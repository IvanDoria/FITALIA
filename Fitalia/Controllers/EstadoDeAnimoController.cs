using Fitalia.Entities;
using Fitalia.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace Fitalia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoDeAnimoController : ControllerBase
    {
        private readonly IEstadoDeAnimoService _IEstadoDeAnimoService;
        private readonly ILogger<EstadoDeAnimoController> _logger;

        public EstadoDeAnimoController(IEstadoDeAnimoService IEstadoDeAnimoService, ILogger<EstadoDeAnimoController> logger)
        {
            _IEstadoDeAnimoService = IEstadoDeAnimoService;
            _logger = logger;
        }

        [HttpGet]
        [Route("ObtenerEstado")]
        public async Task<IActionResult> getEstado(string userId)
        {
            var estado = await _IEstadoDeAnimoService.getEstado(userId);
            return estado != null ? Ok(estado) : BadRequest("No se pudo acceder al estado");
        }

        [HttpPost]
        [Route("SeleccionarEstado")]
        public async Task<IActionResult> guardarEstado(EstadoDeAnimo estado)
        {
            var user = await _IEstadoDeAnimoService.guardarEstado(estado);
            return user == true ? Ok("Se ha guardado el estado exitosamente") : BadRequest("No se pudo guardar el estado");
        }
        
    }
}
