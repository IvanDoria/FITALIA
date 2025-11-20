namespace Fitalia.Queries
{
    public static class RecordatoriosQueries
    {
        public const string GetBySaludFisica = @"
            SELECT Id, Mensaje, Fecha, Activo, Posponerse, UserId, SaludFisicaId
            FROM Recordatorio
            WHERE SaludFisicaId = @SaludFisicaId
            ORDER BY Fecha DESC;
        ";

        public const string GetById = @"
            SELECT Id, Mensaje, Fecha, Activo, Posponerse, UserId, SaludFisicaId
            FROM Recordatorio
            WHERE Id = @Id;
        ";

        public const string Insert = @"
            INSERT INTO Recordatorio (Mensaje, Fecha, Activo, Posponerse, UserId, SaludFisicaId)
            VALUES (@Mensaje, @Fecha, @Activo, @Posponerse, @UserId, @SaludFisicaId);
            SELECT CAST(SCOPE_IDENTITY() AS INT);
        ";

        public const string Update = @"
            UPDATE Recordatorio
            SET Mensaje = @Mensaje,
                Fecha = @Fecha,
                Activo = @Activo,
                Posponerse = @Posponerse
            WHERE Id = @Id;
        ";

        public const string Delete = @"
            DELETE FROM Recordatorio WHERE Id = @Id;
        ";

        public static string GetPendientesParaEnviar = @"
        SELECT
            r.*,
            u.Correo,
            p.Nombre AS NombrePersona,
            s.Tipo AS NombreActividad
        FROM Recordatorio r
        INNER JOIN Usuario u ON r.UserId = u.UserId
        INNER JOIN Persona p ON u.UserId = p.userId
        INNER JOIN SaludFisica s ON r.SaludFisicaId = s.Id
        WHERE r.Activo = 1
          AND r.Fecha <= @Ahora";

        // Query para desactivar el recordatorio una vez enviado
        public static string Desactivar = @"
        UPDATE Recordatorio 
        SET Activo = 0 
        WHERE Id = @Id";



    }
}







