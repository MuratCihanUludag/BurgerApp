namespace BurgerApp.PL.Areas.Identity.Pages.EmailSender
{
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.Extensions.Configuration;
    using System.Net;
    using System.Net.Mail;
    using System.Threading.Tasks;

    namespace YourProject.Services
    {
        public class EmailSenderManager : IEmailSender
        {
            public IConfiguration _configuration { get; set; }
            public EmailSenderManager(IConfiguration configration)
            {
                _configuration = configration;
            }
            public Task SendEmailAsync(string email, string subject, string htmlMessage)
            {
                try
                {


                    var emailConfiguration = _configuration.GetSection("EmailSenderConfiguration").Get<EmailSender>();


                    MailMessage message = new MailMessage();

                    SmtpClient client = new SmtpClient
                    {
                        Port = emailConfiguration.Port,
                        Host = emailConfiguration.Host,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(emailConfiguration.Email, emailConfiguration.Password)
                    };

                    message.From = new MailAddress(emailConfiguration.Email);
                    message.To.Add(new MailAddress(email));
                    message.IsBodyHtml = true;
                    message.Subject = subject;
                    message.Body = htmlMessage;


                    client.Send(message);

                    return Task.CompletedTask;
                }
                catch (Exception e)
                {

                    throw e;
                }

            }
        }
    }
}
