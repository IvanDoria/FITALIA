namespace Fitalia.Queries
{
    public class EstadoDeAnimoQueries
    {
        public static string guardarEstadoDeAnimo = @"INSERT INTO EstadoAnimo (Fecha, TypeAnimo, UserId) VALUES (GETDATE(), @TypeEstadoAnimo, @UserIdDao);";
        public static string obtenerEstadoHoy = @"SELECT UserId,TipoDeAnimo,Fecha FROM EstadoAnimo WHERE UserId = @userId;";
    }
}
