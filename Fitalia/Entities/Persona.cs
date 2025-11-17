namespace Fitalia.Entities
{
    public class Persona
    {
        public Persona()
        {
        }

        public string userId { get; set; }
        public string nombre { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public int edad { get; set; }
        public string numeroDeTelefono { get; set; }
        public string sexo { get; set; }

        public Persona(string userId, string nombre, string apellidoPaterno, string apellidoMaterno, int edad, string numeroDeTelefono, string sexo)
        {
            this.userId = userId;
            this.nombre = nombre;
            this.apellidoPaterno = apellidoPaterno;
            this.apellidoMaterno = apellidoMaterno;
            this.edad = edad;
            this.numeroDeTelefono = numeroDeTelefono;
            this.sexo = sexo;
        }
    }
}
