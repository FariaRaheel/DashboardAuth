using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace DashboardAuth.EmailSender
{
    public class EmailSender : IMailSender
    {
       
        public void MessageSend(Message message)
        {
            try
            {
                var mail = new MailMessage();
                var Client = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("TehreemTecno@gmail.com", "ilkscemxtormzkrj"),
                    EnableSsl=true,
                };
                mail.From = new MailAddress("TehreemTecno@gmail.com", "Test User");
                mail.To.Add(message.Messageto);
                mail.Subject= message.Subject;
                var htmlView = AlternateView.CreateAlternateViewFromString(message.Content, null, MediaTypeNames.Text.Html);
                mail.AlternateViews.Add(htmlView);
                Client.Send(mail);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
