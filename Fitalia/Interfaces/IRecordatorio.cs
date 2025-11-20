using Fitalia.Entities;

namespace Fitalia.Interfaces
{
    public interface IRecordatorio
    {
        Task<List<Recordatorio>> ListarPendientes(DateTime ahora);

    }
}
