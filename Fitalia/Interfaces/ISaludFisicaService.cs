using Fitalia.Entities;

namespace Fitalia.Services
{
    public interface ISaludFisicaService
    {
        Task<int> RegistrarActividad(SaludFisica actividad);
        Task<List<SaludFisica>> ObtenerHistorial(int userId);
        Task<bool> EditarActividad(int id, SaludFisica actividad);
        Task<bool> MarcarComoCumplido(int id);
        Task<bool> EliminarActividad(int id);

    }
}



