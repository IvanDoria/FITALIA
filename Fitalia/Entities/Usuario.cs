using Fitalia.Enumerations;
using System.ComponentModel.DataAnnotations;


namespace Fitalia.Entities
{
    public class Usuario
    {

        private int Id { get; set; }

        private string  NombreUsuario { get; set; }

        private string Correo { get; set; }

        private string Contraseña { get; set; }

        private TypeUser typeUser { get; set; }

        private HabitosSaludables HabitosSaludables { get; set; }

        private  List<Recordatorios> Recordatorios { get; set; }

        private EstadoDeAnimo EstadoDeAnimo { get; set; }


    }
}
