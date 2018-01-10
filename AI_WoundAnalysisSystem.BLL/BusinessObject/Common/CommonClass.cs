
using System;
using System.Net.Mail;

namespace AI_WoundAnalysisSystem.BLL.BusinessObject.Common
{
    /// <summary>
    /// Common class
    /// </summary>
    public class CommonClass
    {
        /// <summary>
        /// Gets or sets request type
        /// </summary>
        public enum RequestType
        {
            /// <summary>
            /// prescription request
            /// </summary>
            Prescription,

            /// <summary>
            /// Create Referral
            /// </summary>
            Referral,
        }


        /// <summary>
        /// enum for months german
        /// </summary>
        public enum Month

        {

            Januar = 1,

            Februar,

            März,

            April,

            Mai,

            Juni,

            Juli,

            August,

            September,

            Oktober,

            November,

            Dezember

        }


        /// <summary>
        /// Send Email Notification
        /// </summary>
        /// <param name="subject">the subject of the mail</param>
        /// <param name="bodyMessage">the message content of the mail</param>
        /// <param name="mailIds">the email id separate with comma</param>
        /// <returns>return true if mail send successfully</returns>
        public bool SendEmailNotification(string subject, string bodyMessage, string mailIds)
        {
            SmtpClient smtpClient = new SmtpClient();
            MailMessage mailMessage = new MailMessage();
            try
            {
                mailMessage.IsBodyHtml = true;
                if (mailIds != string.Empty)
                {
                    string[] tooMail = mailIds.Split(',');
                    if (tooMail != null && tooMail.Length > 0)
                    {
                        for (int i = 0; i < tooMail.Length; i++)
                        {
                            mailMessage.To.Add(new MailAddress(tooMail[i]));
                        }
                    }

                    mailMessage.Subject = subject;
                    mailMessage.Body = bodyMessage;
                    smtpClient.Send(mailMessage);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }
    }
}

