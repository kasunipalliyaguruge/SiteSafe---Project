using System.Threading.Tasks;

namespace SiteSafe4.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string to, string subject, string body);
    }
}
