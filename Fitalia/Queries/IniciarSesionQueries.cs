namespace Fitalia.Queries
{
    public class IniciarSesionQueries
    {
        public static string buscarUsuario = @"
            SELECT P.*, U.NombreUsuario,U.Correo,U.TypeUser
            FROM Persona AS P
            INNER JOIN Usuario AS U
            ON P.userId = U.UserId
            WHERE U.Correo = @UserName AND U.Contraseña = @Password;";

        //public static string buscarUsuario = "SELECT * FROM Persona where userId = 1";
    }
}
