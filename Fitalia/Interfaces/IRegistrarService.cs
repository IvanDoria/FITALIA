using Fitalia.Entities;

namespace Fitalia.Interfaces
{
    public interface IRegistrarService
    {
        public Task<string> RegistrarUsuario(Usuario user);
    }
}
