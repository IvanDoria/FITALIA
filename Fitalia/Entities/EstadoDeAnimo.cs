using Fitalia.Enumerations;

namespace Fitalia.Entities
{
    public class EstadoDeAnimo
    {
        public int UserId { get; set; }
        public TypeAnimo TipoDeAnimo { get; set; }
        public DateTime Fecha { get; set; }

        // === AGREGAR ESTO (Constructor vacío) ===
        public EstadoDeAnimo() { }

        // Tu constructor personalizado (puedes mantenerlo si lo usas en otra parte)
        public EstadoDeAnimo(int userId, int tipoDeAnimo, DateTime fecha)
        {
            UserId = userId;
            TipoDeAnimo = (TypeAnimo)tipoDeAnimo;
            Fecha = fecha;
        }
    }
}
