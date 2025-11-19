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
            actividad.Cumplido = false;
            return await dao.Insertar(actividad);
        }

        public async Task<List<SaludFisica>> ObtenerHistorial(int userId)
        {
            return await dao.ListarPorUsuario(userId);
        }

        public async Task<bool> EditarActividad(int id, SaludFisica actividad)
        {
            return await dao.Editar(id, actividad);
        }

        public async Task<bool> MarcarComoCumplido(int id)
        {
            return await dao.MarcarCumplido(id);
        }

        public async Task<bool> EliminarActividad(int id)
        {
            return await dao.Eliminar(id);
        }

    }
}


