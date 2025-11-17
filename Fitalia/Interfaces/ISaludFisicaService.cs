using Fitalia.Entities;

namespace Fitalia.Services
{
    public interface ISaludFisicaService
    {
        Task<bool> RegistrarActividad(SaludFisica actividad);
        Task<List<SaludFisica>> ObtenerHistorial(int userId);
    }
}
