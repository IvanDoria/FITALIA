namespace Fitalia.Entities
{
    public class ContenidoBienestar
    {
        public int Id { get; set; }
        public string Formato { get; set; } // <--- ¡DEBE SER STRING!
        public string Contenido { get; set; } // <--- ¡DEBE SER STRING!
        public int TypeAnimo { get; set; }

        // ... (Otras propiedades si las tienes, pero verifica las de la BD)
    }
}