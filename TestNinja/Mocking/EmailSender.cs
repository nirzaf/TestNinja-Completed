using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace TestNinja.Mocking
{
    public interface IEmailSender
    {
        void EmailFile(string emailAddress, string emailBody, string filename, string subject);
    }

    public class EmailSender : IEmailSender
    {
        public void EmailFile(string emailAddress, string emailBody, string filename, string subject)
        {
            SmtpClient client = new SmtpClient(SystemSettingsHelper.EmailSmtpHost)
            {
                Port = SystemSettingsHelper.EmailPort,
                Credentials =
                    new NetworkCredential(
                        SystemSettingsHelper.EmailUsername,
                        SystemSettingsHelper.EmailPassword)
            };

            MailAddress from = new MailAddress(SystemSettingsHelper.EmailFromEmail, SystemSettingsHelper.EmailFromName,
                Encoding.UTF8);
            MailAddress to = new MailAddress(emailAddress);

            MailMessage message = new MailMessage(from, to)
            {
                Subject = subject,
                SubjectEncoding = Encoding.UTF8,
                Body = emailBody,
                BodyEncoding = Encoding.UTF8
            };

            message.Attachments.Add(new Attachment(filename));
            client.Send(message);
            message.Dispose();

            File.Delete(filename);
        }
        
    }
}