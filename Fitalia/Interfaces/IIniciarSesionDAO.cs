using Fitalia.Entities;

namespace Fitalia.Interfaces
{
    public interface IIniciarSesionDAO
    {
        public Task<DatosUsuario> buscarUsuario(string userName, string password);

        Task<Usuario> GetUsuarioById(int id);


    }
}