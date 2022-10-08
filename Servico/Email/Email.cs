using Microsoft.Extensions.Configuration;
using Servico.Email;
using System.Net;
using System.Net.Mail;

namespace Entra21.CSharp.Area21.Service.Email
{
    public class EmailService : IEmail
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool Enviar(string email, string subject, string message)
        {
            try
            {
                var host = _configuration.GetValue<string>("SMTP:Host");
                var name = _configuration.GetValue<string>("SMTP:Nome");
                var password = _configuration.GetValue<string>("SMTP:Senha");
                var username = _configuration.GetValue<string>("SMTP:Username");
                var port = _configuration.GetValue<int>("SMTP:Porta");

                var mail = new MailMessage()
                {
                    From = new MailAddress(username, name)
                };

                mail.To.Add(email);
                mail.Subject = subject;
                mail.Body = message;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                using (SmtpClient smtp = new SmtpClient(host, port))
                {
                    smtp.Credentials = new NetworkCredential(username, password);
                    smtp.EnableSsl = true;

                    smtp.Send(mail);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}