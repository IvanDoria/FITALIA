namespace Fitalia.Queries
{
    public static class SaludFisicaQueries
    {
        public const string Insert = @"
            INSERT INTO SaludFisica (UserId, Tipo, DuracionMin, Intensidad, Cumplido, Fecha)
            VALUES (@UserId, @Tipo, @DuracionMin, @Intensidad, @Cumplido, @Fecha)
        ";

        public const string GetById = @"
            SELECT *
            FROM SaludFisica
            WHERE Id = @Id
        ";

        public const string ListarPorUsuario = @"
            SELECT *
            FROM SaludFisica
            WHERE UserId = @UserId
            ORDER BY Fecha DESC
        ";

        public const string Update = @"
            UPDATE SaludFisica SET
                Tipo = @Tipo,
                DuracionMin = @DuracionMin,
                Intensidad = @Intensidad,
                Cumplido = @Cumplido
            WHERE Id = @Id
        ";

        public const string MarcarCumplido = @"
            UPDATE SaludFisica
            SET Cumplido = 1
            WHERE Id = @Id
        ";

        public const string Delete = @"
            DELETE FROM SaludFisica
            WHERE Id = @Id
        ";
    }
}

