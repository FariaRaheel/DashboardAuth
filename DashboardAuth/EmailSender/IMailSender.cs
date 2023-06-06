using Microsoft.AspNetCore.Identity;

namespace DashboardAuth.EmailSender
{
    public interface IMailSender
    {
        public void MessageSend(Message message);
        
    }
}
