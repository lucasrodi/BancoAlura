namespace Banco.Models
{
    public class TransacaoSuspeitaViewModel
    {
        public TransacaoSuspeitaViewModel()
        {
                
        }
        public TransacaoSuspeitaViewModel(string bancoOrigem, string agenciaOrigem, string contaOrigem, string bancoDestino, string agenciaDestino, string contaDestino, string valor)
        {
            BancoOrigem = bancoOrigem;
            AgenciaOrigem = agenciaOrigem;
            ContaOrigem = contaOrigem;
            BancoDestino = bancoDestino;
            AgenciaDestino = agenciaDestino;
            ContaDestino = contaDestino;
            Valor = valor;
        }

        public string BancoOrigem { get; set; }
        public string AgenciaOrigem { get; set; }
        public string ContaOrigem { get; set; }
        public string BancoDestino { get; set; }
        public string AgenciaDestino { get; set; }
        public string ContaDestino { get; set; }
        public string Valor { get; set; }

        public static implicit operator TransacaoSuspeitaViewModel(List<string> v)
        {
            throw new NotImplementedException();
        }
    }
}
