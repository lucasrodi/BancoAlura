using Banco.Models;
using MailKit.Net.Smtp;
using MimeKit;

namespace Banco
{
    public class EmailService
    {
        private IConfiguration _config;
       
        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public EmailService()
        {
        }

        public void EnviarEmail(string[] destinatario, string assunto, string usuarioId, string code)
        {
            Mensagem mensagem = new Mensagem(destinatario, assunto, usuarioId, code);
            var mensagemDeEmail = CriaCorpoDeEmail(mensagem);
            Enviar(mensagemDeEmail);
        }

        private void Enviar(MimeMessage mensagemDeEmail)
        {
            using (var cliente = new SmtpClient())
            {
                try
                {
                    cliente.Connect("smtp.gmail.com", 465, true);
                    cliente.AuthenticationMechanisms.Remove("XOUATH2");
                    cliente.Authenticate("", "");
                    cliente.Send(mensagemDeEmail);
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    cliente.Disconnect(true);
                    cliente.Dispose();  
                }
            }
        }

        private MimeMessage CriaCorpoDeEmail(Mensagem mensagem)
        {
            var mensagemDeEmail = new MimeMessage();
            mensagemDeEmail.From.Add(new MailboxAddress(string.Empty, "lucasrodigheri205@gmail.com"));
            mensagemDeEmail.To.AddRange(mensagem.Destinatario);
            mensagemDeEmail.Subject = mensagem.Assunto;
            mensagemDeEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = mensagem.Conteudo
            };
            return mensagemDeEmail;
        }
    }
}
