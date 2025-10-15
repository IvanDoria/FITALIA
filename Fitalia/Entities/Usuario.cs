using Fitalia.Enumerations;
using System.ComponentModel.DataAnnotations;


namespace Fitalia.Entities
{
    public class Usuario
    {

        public int Id { get; set; }

        public string  NombreUsuario { get; set; }

        public string Correo { get; set; }

        public string Contraseña { get; set; }

        public TypeUser typeUser { get; set; }

        public HabitosSaludables HabitosSaludables { get; set; }

        public  List<Recordatorios> Recordatorios { get; set; }

        public EstadoDeAnimo EstadoDeAnimo { get; set; }


    }
}
