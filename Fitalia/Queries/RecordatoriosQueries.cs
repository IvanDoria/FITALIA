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

        public static string GetPendientesParaEnviar =
    @"SELECT *
      FROM Recordatorio
      WHERE Activo = 1 AND Fecha <= @Ahora";

    }
}







