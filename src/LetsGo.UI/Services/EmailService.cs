﻿using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace LetsGo.UI.Services
{
    public class EmailService
    {
        public async Task Send(string emailTo, string subject, string message)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("Администрация сайта", "ticketboxkg@gmail.com"));
            email.To.Add(MailboxAddress.Parse(emailTo));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = message };
            // send email
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 25, false);
                await client.AuthenticateAsync("ticketboxkg@gmail.com", "9x8Q3NB8uX");
                await client.SendAsync(email);
                await client.DisconnectAsync(true);
            }
        }
    }
}