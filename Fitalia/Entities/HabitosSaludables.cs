namespace Fitalia.Entities
{
    public class HabitosSaludables
    {
        private int ID { get; set; }
        private List<HabitoSaludable> habitos { get; set; } = new List<HabitoSaludable>();
        private List<string> categorias { get; set; } = new List<string>();
        private string recomendacion { get; set; }
        private ContenidoBienestar contenidoBienestar { get; set; }

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
