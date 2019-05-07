using System;
using System.Net;
using System.Net.Mail;
using TestProject.Course2.Resources.Class;
using TestProject.Course2.Resources.Resx;

namespace TestProject.Course2.Reports
{
    public static class EmailSender
    {
        private static NetworkCredential credentials;
        private static MailMessage mail;
        private static SmtpClient smtpClient;

        public static void SendReportEmail()
        {
            try
            {
                SetEmailSenderCredentials(EmailResx.SenderEmailAdress, EmailResx.SenderEmailPassword);
                SetEmailTemplate(EmailResx.SenderEmailAdress, EmailResx.Title, EmailResx.Body);   
                SetEmailReceiverAdress(EmailResx.ReceiverEmailAdress);
                AddHtmlReportAsAttachement();
                CreateSmtpClient();
                SendEmail();               
            }
            catch (Exception e)
            {
                Console.WriteLine("The next error occured when sending the email : " + e.Message);
            }
        }

        public static void SetEmailSenderCredentials(string username , string password)
        {
            credentials = new NetworkCredential(username, password);            
        }

        public static void SetEmailTemplate(string senderEmail , string emailSubject , string emailBody)
        {
            mail = new MailMessage()
            {
                From = new MailAddress(senderEmail),
                Subject = emailSubject,
                Body = emailBody,
            };
        }

        public static void SetEmailReceiverAdress(string emailReceiver)
        {
            mail.To.Add(new MailAddress(emailReceiver));
        }

        public static void AddHtmlReportAsAttachement()
        {          
            var attachment = new Attachment(Paths.ReportFilesFolder + Reporter.ReportFileName);
            mail.Attachments.Add(attachment);
        }

        public static void CreateSmtpClient()
        {
            smtpClient = new SmtpClient()
            {
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = "smtp.gmail.com",
                EnableSsl = true,
                Credentials = credentials
            };
        }

        public static void SendEmail()
        {
            smtpClient.Send(mail);
        }
    }
}
