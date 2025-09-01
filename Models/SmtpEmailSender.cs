
using System.Net;
using System.Net.Mail;

namespace PanelProject.Models
{
    public class SmtpEmailSender : IEmailSender
    {
        private string _host;
        private int _port;
        private string _username;
        private string _password;

        private bool _enableSSL;

        public SmtpEmailSender(string host, int port, string username, string password, bool enableSSL)
        {
            _host = host;
            _port = port;
            _username = username;
            _password = password;
            _enableSSL = enableSSL;
        }




        public Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SmtpClient(_host, _port)
            {
                Credentials = new NetworkCredential(_username, _password),
                EnableSsl = _enableSSL
            };
           
            return client.SendMailAsync(new MailMessage(_username, email,subject,message) {IsBodyHtml=true});

        }
    }
}