using System;
using System.Collections.Generic;
using System.Web;
using System.Net.Mail;
using System.Net;
using System.Configuration;

namespace CodeStixSolution.DAL
{
    public class MailHelper
    {
        public static bool SendMailMessage(string FromDisplayName, string ToDisplayName, string from, string to, string bcc, string cc, string subject, string body)
        {
            bool varResult = false;

            try
            {
                // Instantiate a new instance of MailMessage
                MailMessage mMailMessage = new MailMessage();
                // Set the sender address of the mail message
                mMailMessage.From = new MailAddress(from, FromDisplayName);
                // Set the recepient address of the mail message
                mMailMessage.To.Add(new MailAddress(to, ToDisplayName));

                // Check if the bcc value is null or an empty string
                if ((bcc != null) && (bcc != string.Empty))
                {
                    // Set the Bcc address of the mail message
                    mMailMessage.Bcc.Add(new MailAddress(bcc));
                }
                // Check if the cc value is null or an empty value
                if ((cc != null) && (cc != string.Empty))
                {
                    // Set the CC address of the mail message
                    mMailMessage.CC.Add(new MailAddress(cc));
                }       // Set the subject of the mail message
                mMailMessage.Subject = subject;
                // Set the body of the mail message
                mMailMessage.Body = body;

                // Set the format of the mail message body as HTML
                mMailMessage.IsBodyHtml = true;
                // Set the priority of the mail message to normal
                mMailMessage.Priority = MailPriority.Normal;

                // Instantiate a new instance of SmtpClient
                SmtpClient mSmtpClient = new SmtpClient();

                //--------------------
                //SmtpClient client = new SmtpClient(host, port); //  Create an instance of SmtpClient with your smtp host and port
                //client.Credentials = new NetworkCredential(account, pswd); //  Assign your username and password to connect to gmail

                mSmtpClient.Host = ConfigurationManager.AppSettings["host"];
                mSmtpClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);

                // Un-comment below 3 lines during the Testing through GMail
                mSmtpClient.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["account"], ConfigurationManager.AppSettings["pswd"]);
                mSmtpClient.EnableSsl = true;
                mMailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                //--------------------

                // Send the mail message
                mSmtpClient.Send(mMailMessage);

                varResult = true;

            }
            catch (Exception ex)
            {

                varResult = false;
            }

            return varResult;
        }
    }
}