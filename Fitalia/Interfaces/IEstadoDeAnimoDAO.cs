using Fitalia.Entities;

namespace Fitalia.Interfaces
{
    public interface IEstadoDeAnimoDAO
    {
        public Task<bool> guardarEstadoDeAnimo(EstadoDeAnimo estadoDeAnimo);
        public Task<EstadoDeAnimo> obtenerEstado(string userId);
    }
}
