using Dapper;
using Fitalia.Entities;
using Fitalia.Interfaces;
using Fitalia.Queries;
using System.Data;

namespace Fitalia.DAO
{
    public class RecordatoriosDAO : IRecordatoriosDAO
    {
        private readonly IDbConnection _connection;

        public RecordatoriosDAO(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<Recordatorio>> GetBySaludFisica(int saludFisicaId)
        {
            var rows = await _connection.QueryAsync<Recordatorio>(
                RecordatoriosQueries.GetBySaludFisica,
                new { SaludFisicaId = saludFisicaId });

            return rows.ToList();
        }

        public async Task<Recordatorio> GetById(int id)
        {
            return await _connection.QueryFirstOrDefaultAsync<Recordatorio>(
                RecordatoriosQueries.GetById,
                new { Id = id });
        }

        public async Task<int> Create(Recordatorio model)
        {
            var id = await _connection.ExecuteScalarAsync<int>(
                RecordatoriosQueries.Insert, model);
            return id;
        }

        public async Task<bool> Update(int id, Recordatorio model)
        {
            model.Id = id;
            var rows = await _connection.ExecuteAsync(RecordatoriosQueries.Update, model);
            return rows > 0;
        }

        public async Task Delete(int id)
        {
            await _connection.ExecuteAsync(RecordatoriosQueries.Delete, new { Id = id });
        }

        // Asegúrate de cambiar el tipo de retorno a RecordatorioEmailDTO
        public async Task<List<RecordatorioEmailDTO>> GetPendientesParaEnviar(DateTime ahora)
        {
            // Dapper mapea automáticamente las columnas a las propiedades del DTO
            var rows = await _connection.QueryAsync<RecordatorioEmailDTO>(
                RecordatoriosQueries.GetPendientesParaEnviar,
                new { Ahora = ahora });

            return rows.ToList();
        }

        // Agrega este método para marcarlo como "ya enviado"
        public async Task Desactivar(int id)
        {
            await _connection.ExecuteAsync(RecordatoriosQueries.Desactivar, new { Id = id });
        }

    }
}









