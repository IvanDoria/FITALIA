namespace Fitalia.Interfaces
{
    public interface IGestionarPerfilDAO
    {
        public Task<bool> actualizarNombre(int userId, string nuevoNombre);
        public Task<bool> actualizarApellidoPaterno(int userId, string nuevoApellido);
        public Task<bool> actualizarApellidoMaterno(int userId, string nuevoApellido);
        public Task<bool> actualizarCorreo(int userId, string nuevoCorreo);
        public Task<bool> actualizarContrasena(int userId, string nuevaContrasena);
        public Task<bool> actualizarFotoPerfil(int userId, string nuevaFoto);
        public Task<bool> actualizarFechaNacimiento(int userId, string fechaNueva);

    }
}