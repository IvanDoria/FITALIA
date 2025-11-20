using System.Net;
using System.Net.Mail;

namespace Fitalia.Services
{
    public class EmailService
    {
        // Configura aquí tu correo GMAIL y tu CONTRASEÑA DE APLICACIÓN
        private string _miCorreo = "itmpruebas122@gmail.com\r\n";
        private string _miPassword = "gavyzpmigglwnsdl";

        public void Enviar(string destino, string asunto, string cuerpoHtml)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(_miCorreo, _miPassword),
                    EnableSsl = true,
                };

                var mensaje = new MailMessage
                {
                    From = new MailAddress(_miCorreo, "Fitalia App"),
                    Subject = asunto,
                    Body = cuerpoHtml,
                    IsBodyHtml = true,
                };

                mensaje.To.Add(destino);
                smtpClient.Send(mensaje);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error enviando correo: " + ex.Message);
            }
        }
    }
}