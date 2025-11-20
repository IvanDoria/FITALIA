using Fitalia.Entities;
using System.Collections.Generic;

namespace Fitalia.Interfaces
{
    public interface IDistribucionContenidoService
    {
        // Retorna un objeto que contiene listas separadas de videos e imágenes
        Task<object> ObtenerContenidoPorAnimo(int typeAnimoId);
    }
}