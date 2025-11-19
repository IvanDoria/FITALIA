using Fitalia.Entities;

namespace Fitalia.Interfaces
{
    public interface ISaludFisicaDAO
    {
        Task<bool> Insertar(SaludFisica actividad);
        Task<List<SaludFisica>> ListarPorUsuario(int userId);
        Task<bool> Editar(int id, SaludFisica actividad);
        Task<bool> MarcarCumplido(int id);
        Task<bool> Eliminar(int id);

    }
}


