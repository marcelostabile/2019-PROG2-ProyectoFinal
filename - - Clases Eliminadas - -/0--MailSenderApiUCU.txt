using System;
using System.Net.Mail;

// La siguiente clase esta configurada para funcionar con un servidor de correo de GMail
    public class MailSender
    {
        private string addressFrom; // El e-mail del remitente en @gmail.com

        private string nameFrom;
      
        private string passwordFrom;

        public MailSender(string addressFrom, string nameFrom)
        {
            this.addressFrom = addressFrom;
            this.nameFrom = nameFrom;
        }

        public void GetPassword(string prompt)
        {
            Console.Write(prompt);
            this.passwordFrom = "";

            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                // Backspace Should Not Work
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    this.passwordFrom += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && this.passwordFrom.Length > 0)
                    {
                        this.passwordFrom = this.passwordFrom.Substring(0, (this.passwordFrom.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            } while (true);

            Console.WriteLine();
        }

        public bool SendMail(string addressTo, string asunto, string contenido)
        {
            MailMessage msg = new MailMessage();
            msg.To.Add(addressTo);
            msg.From = new MailAddress(this.addressFrom, this.nameFrom, System.Text.Encoding.UTF8);
            msg.Subject = asunto;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = contenido;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            // Si vas a enviar un correo con contenido html entonces cambia el valor a true
            msg.IsBodyHtml = false;

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(this.addressFrom, this.passwordFrom);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Port = 587;
            // Este es el smtp valido para Gmail
            client.Host = "smtp.gmail.com";
            // Esto es para que vaya a través de SSL que es obligatorio con GMail
            client.EnableSsl = true;

            try
            {
                client.Send(msg);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
