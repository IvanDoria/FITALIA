using Dapper;
using Fitalia.Entities;
using Fitalia.Interfaces;
using Fitalia.Queries;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Fitalia.DAO
{
    public class SaludFisicaDAO : ISaludFisicaDAO
    {
        private readonly string _connectionString;

        public SaludFisicaDAO(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("SQLServerConnection");
        }

        private IDbConnection Connection() =>
            new SqlConnection(_connectionString);

        public async Task<int> Insertar(SaludFisica actividad)
        {
            using var db = Connection();

            return await db.ExecuteAsync(
                SaludFisicaQueries.Insert,
                actividad
            );
        }

        public async Task<SaludFisica> GetById(int id)
        {
            using var db = Connection();

            return await db.QueryFirstOrDefaultAsync<SaludFisica>(
                SaludFisicaQueries.GetById,
                new { Id = id }
            );
        }

        public async Task<List<SaludFisica>> ListarPorUsuario(int userId)
        {
            using var db = Connection();

            var result = await db.QueryAsync<SaludFisica>(
                SaludFisicaQueries.ListarPorUsuario,
                new { UserId = userId }
            );

            return result.ToList();
        }

        public async Task<bool> Editar(int id, SaludFisica actividad)
        {
            using var db = Connection();

            actividad.Id = id;

            var rows = await db.ExecuteAsync(
                SaludFisicaQueries.Update,
                actividad
            );

            return rows > 0;
        }

        public async Task<bool> MarcarCumplido(int id)
        {
            using var db = Connection();

            var rows = await db.ExecuteAsync(
                SaludFisicaQueries.MarcarCumplido,
                new { Id = id }
            );

            return rows > 0;
        }

        public async Task<bool> Eliminar(int id)
        {
            using var db = Connection();

            var rows = await db.ExecuteAsync(
                SaludFisicaQueries.Delete,
                new { Id = id }
            );

            return rows > 0;
        }
    }
}




