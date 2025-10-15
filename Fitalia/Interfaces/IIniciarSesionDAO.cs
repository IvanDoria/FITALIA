using Fitalia.Entities;

namespace Fitalia.Interfaces
{
    public interface IIniciarSesionDAO
    {
        public Task<Usuario> buscarUsuario(Usuario usuario);
    }
}