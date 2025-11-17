namespace Fitalia.Interfaces
{
    public interface IGestionarPerfilService
    {
        public Task<bool> CambiarCorreo(int userId, string Correo);
        public Task<bool> CambiarContrasena(int userId, string Contraseña);
        public Task<bool> CambiarNombre(int userId, string nombre);
        public Task<bool> CambiarApellidoPaterno(int userId, string apellidoPaterno);
        public Task<bool> CambiarApellidoMaterno(int userId, string apellidoMaterno);
        public Task<bool> CambiarFotoPerfil(int userId, string nuevaFoto);
        public Task<bool> CambiarFechaNacimiento(int userId, string fechaNueva);
        

    }
}