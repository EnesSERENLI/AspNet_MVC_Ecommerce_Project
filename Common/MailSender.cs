using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class MailSender
    {
        public static void SendMail(string eMail, string subject, string message)
        {
            //Sender
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("enesserenli1@gmail.com","DisplayName");
            mail.To.Add(eMail);
            mail.Subject = subject;
            mail.Body = message;
            mail.IsBodyHtml = true; 

            //Smtp
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential("enesserenli1@gmail.com", "your password!");
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;

            smtp.Send(mail);
            //Note!
            //If you encounter an error when you want to send mail through your defined gmail account, you need to define permission via the link below.
            //https://www.google.com/settings/security/lesssecureapps
        }
    }
}
