namespace Fitalia.Entities
{
    public class Recordatorio
    {
        public int Id { get; set; }

        public string Mensaje { get; set; }

        public DateTime Fecha { get; set; }

        public Boolean Activo { get; set; }
        public Boolean Posponerse { get; set; }
        public int UserId { get; set; }
        public int SaludFisicaId { get; set; }
        


    }
}
