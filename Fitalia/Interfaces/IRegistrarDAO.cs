using Fitalia.Entities;

namespace Fitalia.Interfaces
{
    public interface IRegistrarDAO
    {
        public Task<string> Registrar (Usuario usuario);
        public Task<string> BuscarCorreo (string correo);
    }
}
