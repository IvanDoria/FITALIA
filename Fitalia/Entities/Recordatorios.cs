namespace Fitalia.Entities
{
    public class Recordatorios
    {
        public int Id { get; set; }

        public string Mensaje { get; set; }

        public DateTime Fecha { get; set; }

        public Boolean Activo { get; set; }

        public Boolean Posponerse { get; set; }

    }
}
