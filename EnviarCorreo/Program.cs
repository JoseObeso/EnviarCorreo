using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;



namespace EnviarCorreo
{
    class Program
    {

        public static event EventHandler EventoOcurrido;
        static void Main(string[] args)
        {



            Console.WriteLine("Enviar Correo");

            EventoOcurrido += OnEventoOcurrido;

            // Simular el evento
            EventoOcurrido?.Invoke(null, EventArgs.Empty);





        }


        private static void OnEventoOcurrido(object sender, EventArgs e)
        {
            EmailSender emailSender = new EmailSender();
            emailSender.SendEmail("jobeso@irtp.gob.pe", "Bienvenidos al Equipo IRTP", "Bienvenido");
           
        }

        public class EmailSender
        {

             
            private string smtpServer = "smtp.gmail.com";
            private int smtpPort = 587; // o el puerto que uses
            private string smtpUser = "irtpbot@irtp.gob.pe";
            private string smtpPass = "Dev#03$March#irtp";

            public void SendEmail(string toEmail, string subject, string body)
            {
                try
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient smtpClient = new SmtpClient(smtpServer);

                    mail.From = new MailAddress(smtpUser);
                    mail.To.Add(toEmail);
                    mail.Subject = subject;
                    mail.IsBodyHtml = true;
                    mail.Body = CuerpoMensaje();
                    smtpClient.Port = smtpPort;
                    smtpClient.Credentials = new NetworkCredential(smtpUser, smtpPass);
                    smtpClient.EnableSsl = true;
                    smtpClient.Send(mail);

                    Console.WriteLine("Correo enviado exitosamente.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al enviar el correo: " + ex.Message);
                    Console.ReadKey();
                }
            }


            public string CuerpoMensaje()
            {
                string m1 = "Bienvenidos al IRTP<br>";
                m1 += "El equipo de desarrollo, esta conformado por <br>";
                m1 += "------------------<br>";
                m1 += " Gracias";

                return m1;


            }



        }




    }
}
