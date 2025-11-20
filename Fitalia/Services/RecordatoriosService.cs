using Fitalia.Entities;
using Fitalia.Interfaces;

namespace Fitalia.Services
{
    public class RecordatoriosService : IRecordatoriosService
    {
        private readonly IRecordatoriosDAO _dao;
        private readonly ISaludFisicaDAO _saludDao;

        public RecordatoriosService(IRecordatoriosDAO dao, ISaludFisicaDAO saludDao)
        {
            _dao = dao;
            _saludDao = saludDao;
        }

        public Task<List<Recordatorio>> GetBySaludFisica(int saludFisicaId)
            => _dao.GetBySaludFisica(saludFisicaId);

        public Task<Recordatorio> GetById(int id)
            => _dao.GetById(id);

        public async Task<int> Create(Recordatorio model)
        {
            // Obtener userId desde el hábito
            var habito = await _saludDao.GetById(model.SaludFisicaId);
            if (habito == null) throw new Exception("Hábito no encontrado");
            model.UserId = habito.UserId;
            return await _dao.Create(model);
        }

        public Task<bool> Update(int id, Recordatorio model)
            => _dao.Update(id, model);

        public Task Delete(int id)
            => _dao.Delete(id);
    }
}






