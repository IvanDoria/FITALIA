using System.ComponentModel.DataAnnotations.Schema;

namespace Fitalia.Entities
{
    public class ContenidoBienestar
    {
        private int Id { get; set; }
        private List<string> Video { get; set; } = new List<string>();
        private List<string> Imagen { get; set; } = new List<string>();
    }
}
