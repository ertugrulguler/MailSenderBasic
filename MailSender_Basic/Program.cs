using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Configuration;

namespace MailSender_Basic
{
    class Program
    {
        [Obsolete]
        static void Main(string[] args)
        {
            var myMail = ConfigurationSettings.AppSettings.Get("mail");
            var password = ConfigurationSettings.AppSettings.Get("password");


            SmtpClient sc = new SmtpClient();
            sc.Port = 587;
            sc.Host = "smtp.gmail.com";
            sc.EnableSsl = true;
            sc.Credentials = new NetworkCredential(myMail,password);

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(myMail, "Deneme");


            mail.To.Add("ertglr.61@outlook.com.tr");

            mail.Subject = "E-Posta Konusu";
            mail.IsBodyHtml = true;
            mail.Body = "E-Posta İçeriği";

            sc.Send(mail);


            Console.ReadKey();
        }
    }
}
