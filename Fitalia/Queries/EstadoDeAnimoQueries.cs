namespace Fitalia.Queries
{
    public class EstadoDeAnimoQueries
    {
        public static string guardarEstadoDeAnimo = @"INSERT INTO EstadoAnimo (Fecha, TypeAnimo, UserId) VALUES (GETDATE(), @TypeEstadoAnimo, @UserIdDao);";
        public static string obtenerEstadoHoy = @"EXEC getEstadoDeAnimo @UserId = @UserIdDao, @fechaImport = @Fecha, @Mensaje = @ResultadoMensaje OUTPUT;";
    }
}
