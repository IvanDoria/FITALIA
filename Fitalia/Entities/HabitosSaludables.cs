namespace Fitalia.Entities
{
    public class HabitosSaludables
    {
        public int ID { get; set; }
        public List<HabitoSaludable> habitos { get; set; } = new List<HabitoSaludable>();
        public List<string> categorias { get; set; } = new List<string>();
        public string recomendacion { get; set; }
        public ContenidoBienestar contenidoBienestar { get; set; }

        public HabitosSaludables(int iD, List<HabitoSaludable> habitos, List<string> categorias,string recomendacion, ContenidoBienestar contenidoBienestar)
        {
            ID = iD;
            this.habitos = habitos;
            this.categorias = categorias;
            this.recomendacion = recomendacion;
            this.contenidoBienestar = contenidoBienestar;
        }
    }
}
