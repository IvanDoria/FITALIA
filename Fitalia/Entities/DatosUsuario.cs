using Fitalia.Enumerations;

namespace Fitalia.Entities
{
    public class DatosUsuario : Persona
    {
        public string NombreUsuario { get; set; }

        public string Correo { get; set; }

        public TypeUser typeUser { get; set; }

        public DatosUsuario() { }

    }
}
