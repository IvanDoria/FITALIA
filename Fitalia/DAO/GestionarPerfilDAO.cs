using Dapper;
using Fitalia.Entities;
using Fitalia.Interfaces;
using Fitalia.Queries;
using Fitalia.Utilities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;
namespace Fitalia.DAO
{
    public class GestionarPerfilDAO : IGestionarPerfilDAO
    {
        private readonly SQLServerConfiguration _connectionString;
        private readonly ILogger<GestionarPerfilDAO> _logger;

        public GestionarPerfilDAO(IOptions<SQLServerConfiguration> connectionString, ILogger<GestionarPerfilDAO> logger)
        {
            _connectionString = connectionString.Value;
            _logger = logger;
        }

        protected SqlConnection Connection()
        {
            return new SqlConnection(_connectionString.ConnectionString);

        }

        public async Task<bool> actualizarNombre(int userId, string nuevoNombre)
        {
            try
            {
                using var db = Connection();
                var result = await db.ExecuteAsync(GestionarPerfilQueries.actualizarNombre, new
                {
                    UserId = userId,
                    NuevoNombre = nuevoNombre
                });
                _logger.LogInformation("Nombre actualizado correctamente.");
                return result > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar nombre: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> actualizarApellidoPaterno(int userId, string nuevoApellido)
        {
            try
            {
                using var db = Connection();
                var result = await db.ExecuteAsync(GestionarPerfilQueries.actualizarApellidoPaterno, new
                {
                    UserId = userId,
                    NuevoApellidoPaterno = nuevoApellido
                });
                _logger.LogInformation("Apellido paterno actualizado correctamente.");
                return result > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar apellido paterno: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> actualizarApellidoMaterno(int userId, string nuevoApellido)
        {
            try
            {
                using var db = Connection();
                var result = await db.ExecuteAsync(GestionarPerfilQueries.actualizarApellidoMaterno, new
                {
                    UserId = userId,
                    NuevoApellidoMaterno = nuevoApellido
                });
                _logger.LogInformation("Apellido materno actualizado correctamente.");
                return result > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar apellido materno: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> actualizarCorreo(int userId, string nuevoCorreo)
        {
            try
            {
                using var db = Connection();
                var result = await db.ExecuteAsync(GestionarPerfilQueries.actualizarCorreo, new
                {
                    UserId = userId,
                    NuevoCorreo = nuevoCorreo
                });
                _logger.LogInformation("Correo actualizado correctamente.");
                return result > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el correo: {ex.Message}");
                return false;
            }
        }

        public async  Task<bool> actualizarContrasena(int userId, string nuevaContrasena)
        {
            try
            {
                using var db = Connection();
                var result = await db.ExecuteAsync(GestionarPerfilQueries.actualizarContrasena, new
                {
                    UserId = userId,
                    NuevaContrasena = nuevaContrasena
                });
                _logger.LogInformation("Contraseña actualizada correctamente.");
                return result > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar la contraseña: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> actualizarFotoPerfil(int userId, string nuevaFoto)
        {
            try
            {
                using var db = Connection();
                var result = await db.ExecuteAsync(GestionarPerfilQueries.actualizarFotoPerfil, new
                {
                    UserId = userId,
                    NuevaFoto = nuevaFoto
                });
                _logger.LogInformation("Foto actualizada correctamente.");
                return result > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar la foto: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> actualizarFechaNacimiento(int userId, string fechaNueva)
        {
            try
            {
                using var db = Connection();
                var result = await db.ExecuteAsync(GestionarPerfilQueries.actualizarFechaNacimiento, new
                {
                    UserId = userId,
                    fechaNacimiento = fechaNueva
                });
                _logger.LogInformation("Fecha actualizada correctamente.");
                return result > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar la fecha: {ex.Message}");
                return false;
            }
        }


    }
}