using DotNote2.Models;

namespace DotNote2.Servicios.Utilities
{
    public class EmailService
    {
        #region ENVIO DE EMAIL (NO MOVER, ESTA HORRIBLE)
        /// <summary>
        /// Funcion que envia un email al usuario seleccionado. <br/>
        /// Construye un email en HTML usando la nota proporcionada.
        /// </summary>
        /// <param name="from">Usuario que envia</param>
        /// <param name="to">Para quien es</param>
        /// <param name="nota">Mensaje a enviar</param>
        /// <returns>True si se envio</returns>
        public static async Task<bool> EnviarEmailAsync(Usuario from, Usuario to, Nota nota)
        {
            if (Email.Default.IsComposeSupported)
            {
                var template = $"<body style=\"font-family: Arial, sans-serif;margin: 0;padding: 0;background-color: #f4f4f4;\">\r\n\r\n  <div style=\"max-width: 600px;margin: 20px auto;background-color: #FFCC33;padding: 20px;border-radius: 5px;box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);\">\r\n    <div style=\"margin-bottom: 20px;text-align: center;\">\r\n      <div style=\"margin-bottom: 10px;color: #1B1B1B;font-size: 24px;\">{nota.Header}</div>\r\n      <div style=\"font-size: 14px;color: #353839;\">\r\n        Enviado por: <strong>{from.NameSurname}</strong><br>\r\n        Fecha: <strong>{nota.Date}</strong><br>\r\n        Hora: <strong>{nota.Time}</strong>\r\n      </div>\r\n    </div>\r\n\r\n    <div style=\"font-size: 16px;color: #000000;line-height: 1.6;\">\r\n      <p>{nota.Body}</p>\r\n </div>\r\n  </div>\r\n\r\n</body>";

                var message = new EmailMessage()
                {
                    Subject = nota.Header,
                    Body = template,
                    BodyFormat = EmailBodyFormat.PlainText,
                    To = new List<string>() { to.Email }
                };

                await Email.Default.ComposeAsync(message);
                return true;
            }
            else
            {
                await MostrarMensaje.Precaucion("Tu dispositivo no cuenta con un servicio establecido de email por default");
                return false;
            }
        }
        #endregion
    }
}
