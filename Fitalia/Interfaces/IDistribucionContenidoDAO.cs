using Fitalia.Entities;

namespace Fitalia.Interfaces
{
    public interface IDistribucionContenidoDAO
    {
        Task<IEnumerable<ContenidoBienestar>> ObtenerContenidoPorAnimo(int typeAnimoId);
    }
}