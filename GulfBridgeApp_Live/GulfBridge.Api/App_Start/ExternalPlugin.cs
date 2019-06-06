using GulfBridge.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace GulfBridge.Api.App_Start
{

    public class ExternalPlugin
    {

        static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ExternalPlugin));
        private static string EmailFrom = ConfigurationManager.AppSettings["EmailFrom"];
        private static string SMTPUsername = ConfigurationManager.AppSettings["SMTPUsername"];
        private static string SMTPPassword = ConfigurationManager.AppSettings["SMTPPassword"];
        private static string SMTPHost = ConfigurationManager.AppSettings["SMTPHost"];
        private static string SMTPPort = ConfigurationManager.AppSettings["SMTPPort"];
        private static string SMTPEnableSSL = ConfigurationManager.AppSettings["SMTPEnableSSL"];


        private static string G_EmailFrom = ConfigurationManager.AppSettings["GEmailFrom"];
        private static string G_SMTPUsername = ConfigurationManager.AppSettings["GSMTPUsername"];
        private static string G_SMTPPassword = ConfigurationManager.AppSettings["GSMTPPassword"];
        private static string G_SMTPHost = ConfigurationManager.AppSettings["GSMTPHost"];
        private static string G_SMTPPort = ConfigurationManager.AppSettings["GSMTPPort"];
        private static string G_SMTPEnableSSL = ConfigurationManager.AppSettings["GSMTPEnableSSL"];


        public static int GenerateRandomNo()
        {
            int _min = 1000;
            int _max = 9999;
            //Random _rdm = new Random();
       
           return SingletoneRandom.Rdm.Next(_min, _max);
        }
        public static string GenerateRandomText()
        {
            int textLength = 1;
            const string Chars = "ABCDEFGHIJKLMNPOQRSTUVWXYZ";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(Chars, textLength)
                    .Select(s => s[SingletoneRandom.Rdm.Next(s.Length)])
                    .ToArray());
            return result;
        }
        public static string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        } //this function Convert to Decord your Password
        public string DecodeFrom64(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }


        public static bool SendEmail(EmailTemplate model)
        {
            bool issuccess = false;
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.To.Add(model.Email);
                    if (!string.IsNullOrEmpty(model.CC_Email))
                        mail.CC.Add(model.CC_Email);
                    mail.From = new MailAddress(EmailFrom);
                    mail.Subject = model.Subject;
                    string Body = model.Body;
                    mail.Body = Body;
                    mail.IsBodyHtml = true;
                    if (!string.IsNullOrEmpty(model.AttachmentPath))
                    {
                        //string weburl=ConfigurationManager.AppSettings["WebUrl"];
                        System.Net.Mail.Attachment attachment;
                        attachment = new System.Net.Mail.Attachment(System.IO.Path.Combine(model.AttachmentPath));
                        mail.Attachments.Add(attachment);
                    }
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = SMTPHost;
                    smtp.Port = Convert.ToInt32(SMTPPort);
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential(SMTPUsername, SMTPPassword); // Enter seders User name and password   
                    smtp.EnableSsl = Convert.ToBoolean(SMTPEnableSSL);
                    smtp.Send(mail);
                    issuccess = true;
                }
            }
            catch (Exception e)
            {
                logger.Error("Exception Stack Trace e:", e);
            }
            return issuccess;
        }



        public static bool SendEmailFromGmail(EmailTemplate model)
        {
            bool issuccess = false;
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.To.Add(model.Email);
                    mail.From = new MailAddress(G_EmailFrom);
                    mail.Subject = model.Subject;
                    string Body = model.Body;
                    mail.Body = Body;
                    mail.IsBodyHtml = true;
                    if (!string.IsNullOrEmpty(model.AttachmentPath))
                    {
                        //string weburl=ConfigurationManager.AppSettings["WebUrl"];
                        System.Net.Mail.Attachment attachment;
                        attachment = new System.Net.Mail.Attachment(System.IO.Path.Combine(model.AttachmentPath));
                        mail.Attachments.Add(attachment);
                    }
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = G_SMTPHost;
                    smtp.Port = Convert.ToInt32(G_SMTPPort);
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential(G_SMTPUsername, G_SMTPPassword); // Enter seders User name and password   
                    smtp.EnableSsl = Convert.ToBoolean(G_SMTPEnableSSL);
                    smtp.Send(mail);
                    issuccess = true;
                }
            }
            catch (Exception e)
            {
                logger.Error("Exception Stack Trace e:", e);
            }
            return issuccess;
        }



        public static string CreateRandomPassword()
        {
            string _allowedChars = "0123456789abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ";
            Random randNum = new Random();
            char[] chars = new char[6];
            int allowedCharCount = _allowedChars.Length;
            for (int i = 0; i < 6; i++)
            {
                chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
            }
            return new string(chars);
        }

        public static string ReadEmailTemplate(AspNetUser model)
        {
            string fildedata = string.Empty;
            try
            {
                var sPath = System.Web.Hosting.HostingEnvironment.MapPath("/ui/" + ConfigurationManager.AppSettings["EmailTemplate"]);
                fildedata = System.IO.File.ReadAllText(sPath);
                fildedata = fildedata.Replace("%username%", model.Email).Replace("%password%", model.PasswordHash).Replace("%Name%", model.UserName);
                return fildedata;
            }
            catch (Exception e)
            {
                logger.Error("Exception Stack Trace e: External Pulgin Read Email Method", e);
            }
            return fildedata;
        }

        public static string ReadCompleteStats()
        {
            string fildedata = string.Empty;
            try
            {
                var sPath = System.Web.Hosting.HostingEnvironment.MapPath("/ui/" + ConfigurationManager.AppSettings["CompltStatusTemplate"]);
                fildedata = System.IO.File.ReadAllText(sPath);
                return fildedata;
            }
            catch (Exception e)
            {
                logger.Error("Exception Stack Trace e: External Pulgin ReadCompleteStats Method", e);
            }
            return fildedata;
        }

        public static string ReadPaymentConform(string applicantname, string refno)
        {
            string fildedata = string.Empty;
            try
            {
                var sPath = System.Web.Hosting.HostingEnvironment.MapPath("/ui/" + ConfigurationManager.AppSettings["PaySuccessTemplate"]);
                fildedata = System.IO.File.ReadAllText(sPath);
                fildedata = fildedata.Replace("%applintname%", applicantname).Replace("%refno%", refno);
                return fildedata;
            }
            catch (Exception e)
            {
                logger.Error("Exception Stack Trace e: External Pulgin ReadPaymentConform Method", e);
                
            }
            return fildedata;
        }

    }



    public class SingletoneRandom
    {
        SingletoneRandom() { }
        static readonly Random _rdm = new Random() ;
        
        public static Random Rdm { get {  return _rdm; } }
    }

    //public class RandamNumberGen
    //{
    //    static RandamNumberGen _instance;
    //    static readonly Random _rdm = new Random();

    //    RandamNumberGen()
    //    {

    //    }


    //    public static RandamNumberGen SingletoneInstance
    //    {
    //        get
    //        {
    //            if (_instance == null)
    //            {
    //                _instance = new RandamNumberGen();
    //            }
    //            return _instance;
    //        }
    //    }

       
    //}
}