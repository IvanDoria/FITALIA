using Fitalia.Entities;

namespace Fitalia.Interfaces
{
    public interface ISaludFisicaDAO
    {
        Task<int> Insertar(SaludFisica actividad);
        Task<SaludFisica> GetById(int id);
        Task<List<SaludFisica>> ListarPorUsuario(int userId);
        Task<bool> Editar(int id, SaludFisica actividad);
        Task<bool> MarcarCumplido(int id);
        Task<bool> Eliminar(int id);
    }
}



