using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace SushiBot
{
    class Email
    {
        const string myMail = "kek.kekov.1990@inbox.ru";
        const string myName = "Kristina";
        const string myPassword = "11235813ILAKa";

        public Email(string emailAdress)
        {
            EmailAdress = emailAdress;
        }

        public string EmailAdress { get; set; }
        public void CreateEMail()
        {          
            MailAddress from = new MailAddress(myMail, myName);
            MailAddress to = new MailAddress(EmailAdress);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Order Info";
            m.Body = "<h2>Your order was accepted</h2>";
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 465);
            smtp.Credentials = new NetworkCredential(myMail, myPassword);
            smtp.EnableSsl = true;
            smtp.Send(m);
            Console.ReadLine();
        }
    }
}
