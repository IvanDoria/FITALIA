using Fitalia.Entities

namespace Fitalia.Interfaces
{
    public interface IIniciarSesionService
    {
        public Task<Usuario> revisar(string UserName, string Password);

    }
}
