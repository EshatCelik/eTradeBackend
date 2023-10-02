using eTradeBackend.Application.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Infrastructure.Services.Mail
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task SendMailAsync(string to, string subject, string body, bool isBodyHtml = true)
        {
            await SendMailAsync(new[] { to }, subject, body, isBodyHtml = true);
        }

        public async Task SendMailAsync(string[] tos, string subject, string body, bool isBodyHtml = true)
        {
            MailMessage mailMessage= new MailMessage();
            mailMessage.IsBodyHtml = isBodyHtml;
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            foreach (var item in tos)
            {
                mailMessage.To.Add(item);
            }
            mailMessage.From=new MailAddress(_configuration["Mail:UserName"],"",Encoding.UTF8);
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Credentials = new NetworkCredential(_configuration["Mail:UserName"], _configuration["Mail:Password"]);
            smtpClient.EnableSsl = true;
            smtpClient.Port = Int32.Parse(_configuration["Mail:Port"]);
            smtpClient.Host = _configuration["Mail:Host"];
            await smtpClient.SendMailAsync(mailMessage);
        }

        public async Task SendResetPasswordMailAsync(string to, string userId, string resetToken)
        {
            StringBuilder stringBuilder= new StringBuilder();

            stringBuilder.AppendLine("Merhaba <br> Eğer yeni şifre talebinde bulunduysanız aşağıdaki linkten şifrenizi yenileyebilirsiniz...<br><strong><a target=\"_blank\" href=\"");
            stringBuilder.AppendLine(_configuration["AngularClientUrl"]);
            stringBuilder.AppendLine("/Update-password");
            stringBuilder.AppendLine(userId);
            stringBuilder.AppendLine("/");
            stringBuilder.AppendLine(resetToken);
            stringBuilder.AppendLine("\">Yeni şifre talebi için tklayınız...</a></strong><br><br><span style:\"font-size:12px;\"> Not: Eğer bu talep tarafınızca gerçekleşmedi ise lütfen bu maili ciddiye almayınız</span><br>");

            await SendMailAsync(to,"şifre Değiştirme Talebi",stringBuilder.ToString());
        }
        public async Task SendCompletedOrderMailAsync(string to, string orderCode, DateTime orderDate, string userFullName)
        {
            string mailContent = $" Merhaba Sn {userFullName} <br>" +
                $"{orderDate} tarihinde spariş ettiğiniz {orderCode} nolu siparişiniz tamamlanmış ve kargoya verilmiştir, iyi günlerde kullanın..  ";

            await SendMailAsync(to, $"{orderCode}'nolu spariş tamamlanmıştır... ", mailContent);
        }
    }
}
