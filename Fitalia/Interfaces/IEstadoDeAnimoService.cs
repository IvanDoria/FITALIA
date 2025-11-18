using Fitalia.Entities;

namespace Fitalia.Interfaces
{
    public interface IEstadoDeAnimoService
    {
        public Task<bool> guardarEstado(EstadoDeAnimo estadoDeAnimo);
        public Task<EstadoDeAnimo> getEstado(string userId);
    }
}
