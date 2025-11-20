namespace Fitalia.Queries
{
    public class EstadoDeAnimoQueries
    {

        public static string guardarEstadoDeAnimo = @"INSERT INTO EstadoAnimo (Fecha, TipoDeAnimo, UserId) VALUES (GETDATE(), @TipoDeAnimo, @UserIdDao);";
        public static string obtenerEstadoHoy = @"SELECT UserId,TipoDeAnimo,Fecha FROM EstadoAnimo WHERE UserId = @userId;";
    }
}
