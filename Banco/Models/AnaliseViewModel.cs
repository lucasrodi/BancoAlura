namespace Banco.Models
{
    public class AnaliseViewModel
    {
        public AnaliseViewModel()
        {

        }
        public AnaliseViewModel(List<TransacaoSuspeitaViewModel> transacaoSuspeitas,
            List<ContaSuspeitaViewModel> contaSuspeitas,
            List<AgenciaSuspeitaViewModels> agenciaSuspeitas)
        {
            TransacaoSuspeitas = transacaoSuspeitas;
            ContaSuspeitas = contaSuspeitas;
            AgenciaSuspeitas = agenciaSuspeitas;
        }

        public List<TransacaoSuspeitaViewModel> TransacaoSuspeitas { get; set; }
        public List<ContaSuspeitaViewModel> ContaSuspeitas { get; set; }

        public List<AgenciaSuspeitaViewModels> AgenciaSuspeitas { get; set; }
    }
}
