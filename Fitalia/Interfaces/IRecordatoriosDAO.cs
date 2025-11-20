using Fitalia.Entities;

namespace Fitalia.Interfaces
{
    public interface IRecordatoriosDAO
    {
        Task<List<Recordatorio>> GetBySaludFisica(int saludFisicaId);
        Task<Recordatorio> GetById(int id);
        Task<int> Create(Recordatorio model);
        Task<bool> Update(int id, Recordatorio model);
        Task Delete(int id);
        Task<List<RecordatorioEmailDTO>> GetPendientesParaEnviar(DateTime ahora);
        Task Desactivar(int id);

    }
}







