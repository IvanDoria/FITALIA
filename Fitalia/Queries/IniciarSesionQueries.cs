namespace Fitalia.Queries
{
    public class IniciarSesionQueries
    {
        // Agregamos 'U.FotoPerfil' al SELECT
        public static string buscarUsuario = @"
            SELECT 
                P.*, 
                U.NombreUsuario,
                U.Correo,
                U.TypeUser,
                U.FotoPerfil  -- <--- ¡ESTO ES LO QUE FALTABA!
            FROM Persona AS P
            INNER JOIN Usuario AS U
            ON P.userId = U.UserId
            WHERE U.Correo = @UserName AND U.Contraseña = @Password;";
    }
}