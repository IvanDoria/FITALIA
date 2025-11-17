using Fitalia.Enumerations;
using System.ComponentModel.DataAnnotations;


namespace Fitalia.Entities
{
    public class Usuario:Persona
    {

        public int Id { get; set; }

        public string  NombreUsuario { get; set; }

        public string Correo { get; set; }

        public string Contraseña { get; set; }

        public TypeUser typeUser { get; set; }

        public HabitosSaludables HabitosSaludables { get; set; }

        public  List<Recordatorios> Recordatorios { get; set; }

        public EstadoDeAnimo EstadoDeAnimo { get; set; }



        public Usuario(int id, string nombreUsuario, string correo, string contraseña, TypeUser typeUser, HabitosSaludables habitosSaludables, List<Recordatorios> recordatorios, EstadoDeAnimo estadoDeAnimo)
        {
            Id = id;
            NombreUsuario = nombreUsuario;
            Correo = correo;
            Contraseña = contraseña;
            this.typeUser = typeUser;
            HabitosSaludables = habitosSaludables;
            Recordatorios = recordatorios;
            EstadoDeAnimo = estadoDeAnimo;
        }



        public Usuario()
        {
        }

        public Usuario(int userId, string nombre, string apellidoPaterno, string apellidoMaterno, string FechaNacimiento, string numeroDeTelefono, string sexo) : base(userId, nombre, apellidoPaterno, apellidoMaterno, FechaNacimiento, numeroDeTelefono, sexo)
        {
        }


    }
}
