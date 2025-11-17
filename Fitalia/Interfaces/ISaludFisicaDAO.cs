using Fitalia.Entities;

namespace Fitalia.DAO
{
    public interface ISaludFisicaDAO
    {
        Task<bool> Insertar(SaludFisica actividad);
        Task<List<SaludFisica>> ListarPorUsuario(int userId);
    }
}
