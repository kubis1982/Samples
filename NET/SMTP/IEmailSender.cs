namespace SMTP {
    using System.Threading;

    internal interface IEmailSender {
        IEmailSender Attachment(string fileName, byte[] data);
        IEmailSender Bcc(string name, string address);
        IEmailSender Body(string body);
        IEmailSender Cc(string name, string address);
        string Send(CancellationToken cancellationToken = default);
        IEmailSender Subject(string subject);
        IEmailSender To(string name, string address);
    }
}