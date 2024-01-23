namespace SMTP.Net {
    using System.Net;
    using System.Net.Mail;
    using System.Threading.Tasks;

    internal class EmailSender(EmailSenderOptions emailSenderOptions) {
        public Task SendEmailAsync(string email, string subject, string message) {
            string mail = emailSenderOptions.UserName;
            string password = emailSenderOptions.Password;

            var client = new SmtpClient(emailSenderOptions.Host, emailSenderOptions.Port) {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, password),
                UseDefaultCredentials = false
            };

            return client.SendMailAsync(mail, email, subject, message);
        }


    }
}
