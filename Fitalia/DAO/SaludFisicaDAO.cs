using Fitalia.Entities;
using Fitalia.Interfaces;
using Microsoft.Data.SqlClient;

namespace Fitalia.DAO
{
    public class SaludFisicaDAO : ISaludFisicaDAO
    {
        private readonly string _connectionString;

        public SaludFisicaDAO(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("SQLServerConnection");
        }

        public async Task<bool> Insertar(SaludFisica actividad)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(@"INSERT INTO SaludFisica 
                (UserId, Tipo, DuracionMin, Intensidad, Cumplido, Fecha) 
                VALUES (@UserId, @Tipo, @DuracionMin, @Intensidad, @Cumplido, @Fecha)", conn);

            cmd.Parameters.AddWithValue("@UserId", actividad.UserId);
            cmd.Parameters.AddWithValue("@Tipo", actividad.Tipo);
            cmd.Parameters.AddWithValue("@DuracionMin", actividad.DuracionMin);
            cmd.Parameters.AddWithValue("@Intensidad", actividad.Intensidad);
            cmd.Parameters.AddWithValue("@Cumplido", actividad.Cumplido);
            cmd.Parameters.AddWithValue("@Fecha", actividad.Fecha);

            await conn.OpenAsync();
            return await cmd.ExecuteNonQueryAsync() > 0;
        }

        public async Task<List<SaludFisica>> ListarPorUsuario(int userId)
        {
            var lista = new List<SaludFisica>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                "SELECT * FROM SaludFisica WHERE UserId = @UserId ORDER BY Fecha DESC", conn);

            cmd.Parameters.AddWithValue("@UserId", userId);

            await conn.OpenAsync();
            var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                lista.Add(new SaludFisica
                {
                    Id = (int)reader["Id"],
                    UserId = (int)reader["UserId"],
                    Tipo = reader["Tipo"].ToString(),
                    DuracionMin = (int)reader["DuracionMin"],
                    Intensidad = reader["Intensidad"].ToString(),
                    Cumplido = (bool)reader["Cumplido"],
                    Fecha = (DateTime)reader["Fecha"]
                });
            }

            return lista;
        }

        public async Task<bool> Editar(int id, SaludFisica actividad)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(@"UPDATE SaludFisica SET
                Tipo = @Tipo,
                DuracionMin = @DuracionMin,
                Intensidad = @Intensidad,
                Cumplido = @Cumplido
                WHERE Id = @Id", conn);

            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Tipo", actividad.Tipo);
            cmd.Parameters.AddWithValue("@DuracionMin", actividad.DuracionMin);
            cmd.Parameters.AddWithValue("@Intensidad", actividad.Intensidad);
            cmd.Parameters.AddWithValue("@Cumplido", actividad.Cumplido);

            await conn.OpenAsync();
            return await cmd.ExecuteNonQueryAsync() > 0;
        }

        public async Task<bool> MarcarCumplido(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                "UPDATE SaludFisica SET Cumplido = 1 WHERE Id = @Id", conn);

            cmd.Parameters.AddWithValue("@Id", id);

            await conn.OpenAsync();
            return await cmd.ExecuteNonQueryAsync() > 0;
        }

        public async Task<bool> Eliminar(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("DELETE FROM SaludFisica WHERE Id = @Id", conn);

            cmd.Parameters.AddWithValue("@Id", id);

            await conn.OpenAsync();
            return await cmd.ExecuteNonQueryAsync() > 0;
        }

    }
}



