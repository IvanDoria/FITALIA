using Fitalia.Entities;

namespace Fitalia.Interfaces
{
    public interface IRegistrarService
    {
        public Task<Boolean> RegistrarUsuario(Persona person, Usuario user);
    }
}
