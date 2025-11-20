namespace Fitalia.Queries
{
    public class GestionarPerfilQueries
    {
        public static string actualizarNombre = @"
            UPDATE Persona
            SET nombre = @NuevoNombre
            WHERE userId = @UserId;
        ";

        public static string actualizarApellidoPaterno = @"
            UPDATE Persona
            SET apellidoPaterno = @NuevoApellidoPaterno
            WHERE userId = @UserId;
        ";

        public static string actualizarApellidoMaterno = @"
            UPDATE Persona
            SET apellidoMaterno = @NuevoApellidoMaterno
            WHERE userId = @UserId;
        ";

        public static string actualizarCorreo = @"
            UPDATE Usuario
            SET Correo = @NuevoCorreo
            WHERE UserId = @UserId;
        ";

        public static string actualizarContrasena = @"
            UPDATE Usuario
            SET Contraseña = @NuevaContrasena
            WHERE UserId = @UserId;
        ";

        public static string actualizarFotoPerfil = @"
            UPDATE Usuario
            SET FotoPerfil = @NuevaFoto
            WHERE UserId = @UserId;
        ";
        public static string actualizarFechaNacimiento = @"
    UPDATE Persona
    SET FechaNacimiento = @fechaNacimiento
    WHERE UserId = @UserId;
";
    }
}