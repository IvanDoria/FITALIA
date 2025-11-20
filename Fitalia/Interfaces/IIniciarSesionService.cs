using Fitalia.Entities;

namespace Fitalia.Interfaces
{
    public interface IIniciarSesionService
    {
        public Task<DatosUsuario> revisar(string UserName, string Password);

    }
}
