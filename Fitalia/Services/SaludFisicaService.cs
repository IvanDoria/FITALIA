using Fitalia.DAO;
using Fitalia.Entities;
using Fitalia.Interfaces;

namespace Fitalia.Services
{
    public class SaludFisicaService : ISaludFisicaService
    {
        private readonly ISaludFisicaDAO dao;

        public SaludFisicaService(ISaludFisicaDAO dao)
        {
            this.dao = dao;
        }

        public async Task<bool> RegistrarActividad(SaludFisica actividad)
        {
            actividad.Fecha = DateTime.Now;
            return await dao.Insertar(actividad);
        }

        public async Task<List<SaludFisica>> ObtenerHistorial(int userId)
        {
            return await dao.ListarPorUsuario(userId);
        }
    }
}

