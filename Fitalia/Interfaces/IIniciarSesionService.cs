using Fitalia.Entities;

namespace Fitalia.Interfaces
{
    public interface IIniciarSesionService
    {
        public Task<Persona> revisar(string UserName, string Password);

    }
}
