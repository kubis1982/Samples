namespace SMTP {
    using MailKit.Net.Smtp;
    using MailKit.Security;
    using MimeKit;

    internal class EmailSender : IEmailSender {
        private readonly MimeMessage mimeMessage;
        private readonly EmailSenderOptions emailSenderOptions;
        private readonly BodyBuilder bodyBuilder;

        public EmailSender(EmailSenderOptions emailSenderOptions) {
            MimeMessage mimeMessage = new();
            mimeMessage.From.Add(new MailboxAddress(emailSenderOptions.FromAddress, emailSenderOptions.FromAddress));
            this.mimeMessage = mimeMessage;
            this.emailSenderOptions = emailSenderOptions;
            this.bodyBuilder = new BodyBuilder();
        }

        public IEmailSender Body(string body) {
            bodyBuilder.HtmlBody = $$"""
    <!DOCTYPE html>
    <html lang="en" xmlns="http://www.w3.org/1999/xhtml" xmlns:o="urn:schemas-microsoft-com:office:office">
        <head>
            <meta charset="UTF-8">
            <meta name="viewport" content="width=device-width,initial-scale=1">
            <meta name="x-apple-disable-message-reformatting">
            <title></title>
            <!--[if mso]>
            <noscript>
            <xml>
                <o:OfficeDocumentSettings>
                <o:PixelsPerInch>96</o:PixelsPerInch>
                </o:OfficeDocumentSettings>
            </xml>
            </noscript>
            <![endif]-->
            <style>
            table, td, div, h1, p {font-family: Arial, sans-serif;}
            </style>
        </head>
        <body style="margin:0;padding:0;">
            <table role="presentation" style="width:100%;border-collapse:collapse;border:0;border-spacing:0;background:#ffffff;">
            <tr>
                <td align="center" style="padding:0;">
                <table role="presentation" style="width:1024px;border-collapse:collapse;border:1px solid #cccccc;border-spacing:0;text-align:left;">
                    <tr>
                    <td align="center" style="padding:40px 0 30px 0;background:#70bbd9;">
                        <img style="height:auto;display:block;" alt="" src="https://link/assets/logo-271bfd74.png" />
                    </td>
                    </tr>
                    <tr>
                    <td style="padding:36px 30px 42px 30px;">
                        <table role="presentation" style="width:100%;border-collapse:collapse;border:0;border-spacing:0;">
                        <tr>
                            <td style="padding:0 0 36px 0;color:#153643;">{{body}}</td>
                        </tr>                   
                        </table>
                    </td>
                    </tr>
                    <tr>
                    <td style="padding:30px;background:#ee4c50;">
                        <table role="presentation" style="width:100%;border-collapse:collapse;border:0;border-spacing:0;font-size:9px;font-family:Arial,sans-serif;">
                        <tr>
                            <td style="padding:0;width:50%;" align="left">
                            <p style="margin:0;font-size:14px;line-height:16px;font-family:Arial,sans-serif;color:#ffffff;">
                                &reg; 7Technology 2024<br/><a href="https://link.com" style="color:#ffffff;text-decoration:underline;">prodiqa.com</a>
                            </p>
                            </td>
                            <td style="padding:0;width:50%;" align="right">
                            <table role="presentation" style="border-collapse:collapse;border:0;border-spacing:0;">
                                <tr>
                                <td style="padding:0 0 0 10px;width:38px;">
                                    <a href="http://www.facebook.com/" style="color:#ffffff;"><img src="https://assets.codepen.io/210284/fb_1.png" alt="Facebook" width="38" style="height:auto;display:block;border:0;" /></a>
                                </td>
                                </tr>
                            </table>
                            </td>
                        </tr>
                        </table>
                    </td>
                    </tr>
                </table>
                </td>
            </tr>
            </table>
        </body>
    </html>
    """;
            return this;
        }

        public IEmailSender Subject(string subject) {
            mimeMessage.Subject = subject;
            return this;
        }

        public IEmailSender To(string name, string address) {
            mimeMessage.To.Add(new MailboxAddress(name, address));
            return this;
        }

        public IEmailSender Cc(string name, string address) {
            mimeMessage.Cc.Add(new MailboxAddress(name, address));
            return this;
        }

        public IEmailSender Bcc(string name, string address) {
            mimeMessage.Bcc.Add(new MailboxAddress(name, address));
            return this;
        }

        public IEmailSender Attachment(string fileName, byte[] data) {
            bodyBuilder.Attachments.Add(fileName, data);
            return this;
        }

        public string Send(CancellationToken cancellationToken = default) {
            using var smtpClient = new SmtpClient();
            smtpClient.Connect(emailSenderOptions.Host, emailSenderOptions.Port, SecureSocketOptions.StartTls, cancellationToken);
            smtpClient.Authenticate(emailSenderOptions.UserName, emailSenderOptions.Password, cancellationToken);
            mimeMessage.Body = bodyBuilder.ToMessageBody(); 
            var result = smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true, cancellationToken);
            return result;
        }
    }
}
