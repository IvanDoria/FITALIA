namespace Fitalia.Entities
{
    public class SaludFisica
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Tipo { get; set; }
    public int DuracionMin { get; set; }
    public string Intensidad { get; set; }
    public DateTime Fecha { get; set; }
    public bool Cumplido { get; set; }

    }
}



