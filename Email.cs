using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace SushiBot
{
    class Email
    {
        public void CreateEMail()
        {
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress("yuput26@gmail.com", "Kristush");
            // кому отправляем
            MailAddress to = new MailAddress("wgdetective@gmail.com");
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "Хехехехехе";
            // текст письма
            m.Body = "<h2>Вам письмишко!</h2>";
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("yuput26@gmail.com", "P%hR#s6uggZ-8cQ");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}
