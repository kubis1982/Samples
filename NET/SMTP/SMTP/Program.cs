// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Configuration;
using SMTP;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
ServicePointManager.ServerCertificateValidationCallback = MyRemoteCertificateValidationCallback;
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddUserSecrets<Program>().Build();

EmailSenderOptions emailSenderOptions = new();

configuration.GetSection("EmailSender").Bind(emailSenderOptions);

var emailSender = new EmailSender(emailSenderOptions);
await emailSender.SendEmailAsync("mariusz.swiatnicki@gmail.com", "Subject", "Próba1");

Console.WriteLine("Hello, World!");

static bool MyRemoteCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) {
    bool isOk = true;
    // If there are errors in the certificate chain, look at each error to determine the cause.
    if (sslPolicyErrors != SslPolicyErrors.None) {
        for (int i = 0; i < chain.ChainStatus.Length; i++) {
            if (chain.ChainStatus[i].Status != X509ChainStatusFlags.RevocationStatusUnknown) {
                chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
                chain.ChainPolicy.RevocationMode = X509RevocationMode.Online;
                chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 1, 0);
                chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllFlags;
                bool chainIsValid = chain.Build((X509Certificate2)certificate);
                if (!chainIsValid) {
                    isOk = false;
                }
            }
        }
    }
    return isOk;

}

