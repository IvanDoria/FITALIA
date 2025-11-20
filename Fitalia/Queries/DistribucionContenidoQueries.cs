namespace Fitalia.Queries
{
    public class DistribucionContenidoQueries
    {
        // Consulta para obtener todo el contenido (videos e imágenes) asociado a un TypeAnimo específico.
        // Se ordena por Formato para tener videos juntos e imágenes juntas.
        public static string ObtenerContenidoPorAnimo = @"
            SELECT
                Id,
                Formato,
                Contenido,
                TypeAnimo
            FROM
                ContenidoBienestar
            WHERE
                TypeAnimo = @TypeAnimoId
        ";
    }
}