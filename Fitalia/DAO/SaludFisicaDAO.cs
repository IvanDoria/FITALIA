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
                (UserId, Tipo, DuracionMin, Intensidad, Fecha) 
                VALUES (@UserId, @Tipo, @DuracionMin, @Intensidad, @Fecha)", conn);

            cmd.Parameters.AddWithValue("@UserId", actividad.UserId);
            cmd.Parameters.AddWithValue("@Tipo", actividad.Tipo);
            cmd.Parameters.AddWithValue("@DuracionMin", actividad.DuracionMin);
            cmd.Parameters.AddWithValue("@Intensidad", actividad.Intensidad);
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
                    Fecha = (DateTime)reader["Fecha"]
                });
            }

            return lista;
        }
    }
}

