//using System.Net;
//using System.Net.Mail;
//using Microsoft.Extensions.Options;

//namespace SiteSafe4.Services
//{
//    public class EmailSettings
//    {
//        public string From { get; set; } = "";
//        public string SmtpServer { get; set; } = "";
//        public int Port { get; set; }
//        public string Username { get; set; } = "";
//        public string Password { get; set; } = "";
//    }

//    public interface IEmailSender
//    {
//        Task SendEmailAsync(string to, string subject, string body);
//    }

//    public class EmailSender : IEmailSender
//    {
//        private readonly EmailSettings _emailSettings;

//        public EmailSender(IOptions<EmailSettings> emailSettings)
//        {
//            _emailSettings = emailSettings.Value;
//        }

//        public async Task SendEmailAsync(string to, string subject, string body)
//        {
//            var message = new MailMessage();
//            message.From = new MailAddress(_emailSettings.From);
//            message.To.Add(to);
//            message.Subject = subject;
//            message.Body = body;
//            message.IsBodyHtml = true;

//            using var client = new SmtpClient(_emailSettings.SmtpServer, _emailSettings.Port)
//            {
//                Credentials = new NetworkCredential(_emailSettings.Username, _emailSettings.Password),
//                EnableSsl = true
//            };

//            await client.SendMailAsync(message);
//        }
//    }
//}
