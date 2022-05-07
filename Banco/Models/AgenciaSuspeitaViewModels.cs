namespace Banco.Models
{
    public class AgenciaSuspeitaViewModels
    {
        public AgenciaSuspeitaViewModels()
        {

        }
        public AgenciaSuspeitaViewModels(string bancoDestino, string agenciaDestino, string valorMovimentado, string tipoMovimentacao)
        {
            BancoDestino = bancoDestino;
            AgenciaDestino = agenciaDestino;
            ValorMovimentado = valorMovimentado;
            TipoMovimentacao = tipoMovimentacao;
        }

        public string BancoDestino { get; set; }
        public string AgenciaDestino { get; set; }
        public string ValorMovimentado { get; set; }
        public string TipoMovimentacao { get; set; }
    }
}
