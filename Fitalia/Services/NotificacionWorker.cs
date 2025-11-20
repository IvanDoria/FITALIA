using Fitalia.Interfaces;
using Fitalia.Entities; // Para el DTO

namespace Fitalia.Services
{
    public class NotificacionWorker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        // Instanciamos el servicio de envío de correo (o inyéctalo si prefieres)
        private readonly EmailService _emailService = new EmailService();

        public NotificacionWorker(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    // Creamos un scope porque IDbConnection suele ser Scoped
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var recordatoriosDAO = scope.ServiceProvider.GetRequiredService<IRecordatoriosDAO>();

                        // 1. Buscamos los pendientes (Pasamos la hora actual)
                        var lista = await recordatoriosDAO.GetPendientesParaEnviar(DateTime.Now);

                        foreach (var item in lista)
                        {
                            if (!string.IsNullOrEmpty(item.Correo))
                            {
                                // 2. Preparamos el correo
                                string asunto = $"🔔 Fitalia: Hora de {item.NombreActividad}";
                                string cuerpo = $@"
                                    <h2>Hola {item.NombrePersona}, es hora de moverte.</h2>
                                    <p>Actividad: <strong>{item.NombreActividad}</strong></p>
                                    <p>Nota: {item.Mensaje}</p>
                                    <p>Hora: {item.Fecha:HH:mm}</p>";

                                // 3. Enviamos
                                _emailService.Enviar(item.Correo, asunto, cuerpo);

                                // 4. Desactivamos en BD para no enviarlo de nuevo
                                await recordatoriosDAO.Desactivar(item.Id);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error en notificaciones: {ex.Message}");
                }

                // Esperar 1 minuto (60,000 ms)
                await Task.Delay(60000, stoppingToken);
            }
        }
    }
}