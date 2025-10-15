using Fitalia.Entities;

namespace Fitalia.Interfaces
{
    public interface IIniciarSesionDAO
    {
        public Task<Persona> buscarUsuario(string userName, string password);
    }
}