using System.Net;
using System.Net.Mail;
using Domain.Interfaces.IServices;
using Microsoft.Extensions.Configuration;

namespace DataAccess.EFCore.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly IConfiguration _config;
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _senderEmail;
        private readonly string _senderPassword;

        public EmailSenderService(IConfiguration config)
        {
            _config = config;
            _smtpServer = _config["GmailSMTP:smtpServer"]!;
            _smtpPort = _config.GetValue<int>("GmailSMTP:smtpPort")!;
            _senderEmail = _config["GmailSMTP:senderEmail"]!;
            _senderPassword = _config["GmailSMTP:senderPassword"]!;
        }

        public async Task SendEmailAsync(string email, string subjec, string htmlMessage)
        {
            var client = new SmtpClient(_smtpServer)
            {
                Port = _smtpPort,
                Credentials = new NetworkCredential(_senderEmail, _senderPassword),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_senderEmail),
                Subject = subjec,
                Body = htmlMessage,
                IsBodyHtml = true
            };
            mailMessage.To.Add(email);
            try
            {
                await client.SendMailAsync(mailMessage);
            }
            catch (SmtpException ex)
            {
                throw new Exception("Lỗi ở đây: ", ex);
            }
        }
    }
}
