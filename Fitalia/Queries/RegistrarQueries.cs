namespace Fitalia.Queries
{
    public class RegistrarQueries
    {
        public static string nuevoRegistro = @"EXEC InsertarDatosPersonaUsuario @nombreInsertado, @apellidoPaternoInsertado, @apellidoMaternoInsertado, @fechaNacimientoInsertado, @numeroDeTelefonoInsertado, @sexoInsertado, @NombreUsuarioInsertado, @CorreoInsertado, @ContraseñaInsertado, @TypeUserInsertado, @Mensaje OUTPUT";

        public static string registrarPersona = @"INSERT INTO Persona (nombre, apellidoPaterno, apellidoMaterno, FechaNacimiento, numeroDeTelefono, sexo) 
                                                VALUES ('Carlos', 'Ramírez', 'López', 25, '3001234567', 'Masculino');";
        public static string registrarUsuario = @"INSERT INTO Usuario (UserId, NombreUsuario, Correo, Contraseña, TypeUser)
                                                VALUES ((SELECT TOP 1 userId FROM Persona ORDER BY userId DESC), 
                                                'carlos25', 'carlos@mail.com', 'pass123', 1);";
        public static string buscarCorreo = @"SELECT UserId FROM Usuario WHERE Correo = @Correo;";
    }
}
