using Fitalia.Entities;
using Fitalia.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Fitalia.Services
{
    public class DistribucionContenidoService : IDistribucionContenidoService
    {
        private readonly IDistribucionContenidoDAO _IDistribucionContenidoDAO;
        private readonly ILogger<DistribucionContenidoService> _logger;

        public DistribucionContenidoService(IDistribucionContenidoDAO IDistribucionContenidoDAO, ILogger<DistribucionContenidoService> logger)
        {
            _IDistribucionContenidoDAO = IDistribucionContenidoDAO;
            _logger = logger;
        }

        public async Task<object> ObtenerContenidoPorAnimo(int typeAnimoId)
        {
            var contenidoRaw = await _IDistribucionContenidoDAO.ObtenerContenidoPorAnimo(typeAnimoId);

            if (!contenidoRaw.Any())
            {
                _logger.LogInformation($"No se encontró contenido para el ánimo ID: {typeAnimoId}");
                return null;
            }

            // Dentro de DistribucionContenidoService.cs

            // ...

            var contenidoAgrupado = contenidoRaw
                .GroupBy(c => c.Formato.ToLower()) // Asegúrate que c.Formato no es null aquí
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(c => c.Contenido).ToList() // Asegúrate que c.Contenido no es null aquí
                );

            // ...

            // Devolvemos un objeto con las listas separadas (ej: { "video": [...], "imagen": [...] })
            return new
            {
                Videos = contenidoAgrupado.GetValueOrDefault("video", new List<string>()),
                Imagenes = contenidoAgrupado.GetValueOrDefault("imagen", new List<string>())
            };
        }
    }
}