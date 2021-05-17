using Clean.Architecture.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Architecture.Core.Services
{
    public class EmailMessageSenderService : IMessageSender
    {
        public void SendGuestbookNotificationEmail(string toAddress, string messageBody)
        {
            var message = new MailMessage();
            message.To.Add(new MailAddress(toAddress));
            message.From = new MailAddress("donotreply@gmail.com");
            message.Subject = "New GuestBook added";
            message.Body = messageBody;
            using(var client=new SmtpClient("localhost"))
            {
                client.Send(message);
            }

        }
    }
}
