namespace Fitalia.Entities
{
    // Heredamos de Recordatorio para tener ya el Id, Fecha, Mensaje, etc.
    public class RecordatorioEmailDTO : Recordatorio
    {
        // Datos del Usuario
        public string Correo { get; set; }
        public string NombrePersona { get; set; }

        // Datos de la Actividad Física
        public string NombreActividad { get; set; } // Vendrá del campo 'Tipo' de SaludFisica
    }
}
