using System.ComponentModel.DataAnnotations.Schema;

namespace Fitalia.Entities
{
    public class ContenidoBienestar
    {
        public int Id { get; set; }
        public List<string> Video { get; set; } = new List<string>();
        public List<string> Imagen { get; set; } = new List<string>();
    }
}
