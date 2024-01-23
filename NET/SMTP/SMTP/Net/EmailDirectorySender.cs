namespace SMTP.Net {
    using System;
    using System.Net.Mail;
    using System.Threading.Tasks;

    internal class EmailDirectorySender {
        public Task Send(string email, string subject, string message) {
            string mail = "test@test.com";

            var client = new SmtpClient() {
                DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
                PickupDirectoryLocation = AppDomain.CurrentDomain.BaseDirectory
            };

            return client.SendMailAsync(mail, email, subject, message);
        }
    }
}
