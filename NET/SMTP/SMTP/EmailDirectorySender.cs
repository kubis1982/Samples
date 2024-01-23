namespace SMTP {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Text;
    using System.Threading.Tasks;

    internal class EmailDirectorySender : IEmailSender {
        public Task SendEmailAsync(string email, string subject, string message) {
            string mail = "test@test.com";
            
            var client = new SmtpClient() {
                DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
                PickupDirectoryLocation = AppDomain.CurrentDomain.BaseDirectory
            };

            return client.SendMailAsync(mail, email, subject, message);
        }
    }
}
