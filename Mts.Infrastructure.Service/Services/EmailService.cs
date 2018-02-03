using Microsoft.Extensions.Options;
using Mts.Core.Dto;
using Mts.Core.Dto.Config;
using Mts.Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Mts.Infrastructure.Service.Services
{
    public class EmailService : IEmailService
    {
        private readonly SmtpConfig _smtpConfig;
        public EmailService(IOptions<SmtpConfig> smtpConfig)
        {
            _smtpConfig = smtpConfig.Value;
        }

        public void Send(EmailBody emailBody)
        {
            SmtpClient client = new SmtpClient(_smtpConfig.Server,_smtpConfig.Port);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(_smtpConfig.Username, _smtpConfig.Password);

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(emailBody.From);
            mailMessage.To.Add(emailBody.To);
            mailMessage.Body = emailBody.Content;
            mailMessage.Subject = emailBody.Subject;
            mailMessage.IsBodyHtml = true;
            client.Send(mailMessage);
        }
    }
}
