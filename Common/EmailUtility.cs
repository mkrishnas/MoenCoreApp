using Models.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Common
{
    public static class EmailUtility
    {
        public static void SendEmail(EmailSMTPInfo emailSetting, EmailQueue mailItem)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(mailItem.EmailFrom);
                message.To.Add(new MailAddress(mailItem.EmailTo));
                message.Subject = mailItem.EmailSubject;
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = mailItem.EmailBody;
                smtp.Port = emailSetting.SMTPPort;
                smtp.Host = emailSetting.SMPTHost; //for gmail host  
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(emailSetting.SMPTUserName, emailSetting.SMTPPassword);
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception ex)
            {

            }

        }
    }
}
