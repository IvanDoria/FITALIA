using Fitalia.Enumerations;

namespace Fitalia.Entities
{
    public class EstadoDeAnimo
    {
        public int UserId { get; set; }
        public TypeAnimo Estado{ get; set; }

        public EstadoDeAnimo(TypeAnimo estado, int userId)
        {
            Estado = estado;
            UserId = userId;
        }

    }
}
