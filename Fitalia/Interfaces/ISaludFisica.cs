using Fitalia.Entities;

namespace Fitalia.Interfaces
{
    public interface ISaludFisica
    {
        Task<bool> Insertar(SaludFisica actividad);
        Task<List<SaludFisica>> ListarPorUsuario(int userId);
        
    }
}

