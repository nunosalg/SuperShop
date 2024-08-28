using System;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;

namespace SuperShop.Helpers
{
    public class MailHelper : IMailHelper
    {
        private readonly IConfiguration _configuration;

        public MailHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Response SendEmail(string to, string subject, string body)
        {
            var nameFrom = _configuration["Mail:NameFrom"];
            var from = _configuration["Mail:From"];
            var smtp = _configuration["Mail:Smtp"];
            var port = _configuration["Mail:Port"];
            var password = _configuration["Mail:Password"];

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(nameFrom, from));
            message.To.Add(new MailboxAddress(to, to));
            message.Subject = subject;

            var bodybuilder = new BodyBuilder
            {
                HtmlBody = body,
            };
            message.Body = bodybuilder.ToMessageBody();

            try
            {
                //// Carregar as credenciais do OAuth
                //var credential = GoogleCredential.FromFile("C:\\Projetos\\SuperShop\\supershop-433912-b4c165731d85.json")
                //    .CreateScoped("https://www.googleapis.com/auth/gmail.send");

                //// Garantir que o token está atualizado
                //var accessToken = await credential.UnderlyingCredential.GetAccessTokenForRequestAsync();

                using (var client = new SmtpClient())
                {
                    client.Connect(smtp, int.Parse(port), SecureSocketOptions.StartTls);

                    //// Usar OAuth 2.0 para autenticação
                    //var oauth2 = new SaslMechanismOAuth2(from, accessToken);
                    //client.Authenticate(oauth2);

                    client.Authenticate(from, password);

                    client.Send(message);
                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.ToString()
                };
            }

            return new Response
            {
                IsSuccess = true,
            };
        }
    }
}
