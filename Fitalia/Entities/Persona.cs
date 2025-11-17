namespace Fitalia.Entities
{
    public class Persona
    {
        public Persona()
        {
        }

        public int userId { get; set; }
        public string nombre { get; set; }
        public string? apellidoPaterno { get; set; }
        public string? apellidoMaterno { get; set; }
        public string FechaNacimiento { get; set; }
        public string? numeroDeTelefono { get; set; }
        public string sexo { get; set; }

        public Persona(int userId, string nombre, string apellidoPaterno, string apellidoMaterno, string fechaNacimiento, string numeroDeTelefono, string sexo)
        {
            this.userId = userId;
            this.nombre = nombre;
            this.apellidoPaterno = apellidoPaterno;
            this.apellidoMaterno = apellidoMaterno;
            this.FechaNacimiento = fechaNacimiento;
            this.numeroDeTelefono = numeroDeTelefono;
            this.sexo = sexo;
        }
    }
}
