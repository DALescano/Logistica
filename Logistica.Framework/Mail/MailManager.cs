using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Logistica.Framework
{
    public class MailManager
    {
        public static void Send(string from,string to,string subject,string body)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(from);
                mail.To.Add(to);
                mail.Subject = subject;
                mail.Body = body;

                //System.Net.Mail.Attachment attachment;
                ////attachment = new System.Net.Mail.Attachment("c:/textfile.txt");
                //mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(from, "password");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch { }
        }
    }
}
