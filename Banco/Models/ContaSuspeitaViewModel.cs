namespace Banco.Models
{
    public class ContaSuspeitaViewModel
    {
        public ContaSuspeitaViewModel()
        {
                
        }
        public ContaSuspeitaViewModel(string bancoDestino, string agenciaDestino, string contaDestino, string valorMovimentado, string tipoMovimentacao)
        {
            BancoDestino = bancoDestino;
            AgenciaDestino = agenciaDestino;
            ContaDestino = contaDestino;
            ValorMovimentado = valorMovimentado;
            TipoMovimentacao = tipoMovimentacao;
        }

        public string BancoDestino { get; set; }
        public string AgenciaDestino { get; set; }
        public string ContaDestino { get; set; }
        public string ValorMovimentado { get; set; }
        public string TipoMovimentacao { get; set; }
    }
}