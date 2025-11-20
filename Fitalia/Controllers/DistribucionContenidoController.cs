using Fitalia.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Fitalia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // El nombre del controlador por convención es DistribucionContenidoController
    public class DistribucionContenidoController : ControllerBase
    {
        private readonly IDistribucionContenidoService _IDistribucionContenidoService;
        private readonly ILogger<DistribucionContenidoController> _logger;

        public DistribucionContenidoController(IDistribucionContenidoService IDistribucionContenidoService, ILogger<DistribucionContenidoController> logger)
        {
            _IDistribucionContenidoService = IDistribucionContenidoService;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene videos e imágenes de bienestar basados en el estado de ánimo del usuario.
        /// </summary>
        /// <param name="animoId">ID del tipo de ánimo (ej: 5 para Feliz).</param>
        /// <returns>Objeto JSON con listas de videos e imágenes.</returns>
        [HttpGet]
        [Route("ObtenerContenido")]
        // Usamos [FromQuery] para forzar la lectura del parámetro desde la URL
        public async Task<IActionResult> ObtenerContenido([FromQuery] int animoId)
        {
            if (animoId <= 0 || animoId > 5) // Validamos que el ID del ánimo esté en el rango de tu TypeAnimo
            {
                return BadRequest("El ID del ánimo debe ser un valor válido (1 a 5).");
            }

            var contenido = await _IDistribucionContenidoService.ObtenerContenidoPorAnimo(animoId);

            if (contenido == null)
            {
                _logger.LogWarning($"No se encontró contenido de bienestar para ánimo ID: {animoId}");
                return NotFound("No se encontró contenido asociado a este estado de ánimo.");
            }

            // Devuelve 200 OK con el objeto { Videos: [...], Imagenes: [...] }
            return Ok(contenido);
        }
    }
}