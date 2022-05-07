using MimeKit;

namespace Banco.Models
{
    public class Mensagem
    {
        public List<MailboxAddress> Destinatario { get; set; }
        public string Assunto { get; set; }
        public string Conteudo { get; set; }
        public Mensagem(IEnumerable<string> destinatario, string assunto,string ususarioId,string codigo)
        {
            Destinatario = new List<MailboxAddress>();
            Destinatario.AddRange(destinatario.Select(d=> new MailboxAddress(string.Empty,d)));
            Assunto = assunto;
            Conteudo = $"https://localhost:7031/AtivaUsuario?UsuarioId={ususarioId}&CodigoDeAtivacao={codigo}";
        }
    }
}
