using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace OnlineStore.Data.Services
{
    public interface INotificationService
    {
        void SendMailToClient(string subject, string body, string clientMail);
    }

    public class NotificationService : INotificationService
    {

        public NotificationService() {}

        public void SendMailToClient(string subject, string body, string clientMail)
        {
            //const string host = "mail.google.com";
            //const string fromEmail = "onlinestore@gmail.com";
            //const string fromPassword = "password";
            //string toEmail = clientMail;
            //var fromAddress = new MailAddress(fromEmail, "OnlineStore");
            //var toAddress = new MailAddress(toEmail, "To Client");
            //var smtp = new SmtpClient
            //{
            //    Host = host,
            //    Port = 26,
            //    EnableSsl = false,
            //    DeliveryMethod = SmtpDeliveryMethod.Network,
            //    UseDefaultCredentials = false,
            //    Credentials = new System.Net.NetworkCredential(fromAddress.Address, fromPassword),
            //    Timeout = 10000
            //};
            //using var message = new MailMessage(fromAddress, toAddress)
            //{
            //    IsBodyHtml = true,
            //    Subject = subject,
            //    Body = body
            //};
            //smtp.Send(message);

            return;
        }
    }
}
