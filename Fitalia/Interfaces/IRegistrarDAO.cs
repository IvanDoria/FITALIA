namespace Fitalia.Interfaces
{
    public interface IRegistrarDAO
    {
        Task<Boolean> Registrar (List<string> datos);
    }
}
