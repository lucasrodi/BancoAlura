using Banco.Models;
using Microsoft.AspNetCore.Mvc;

namespace Banco.Controllers
{
    public class AnalizarTransacoesController : Controller
    {
        ApplicationContext context = new ApplicationContext();
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Analizar(string data)
        {
            var transferencias = context.transferencias.ToList();

            List<TransacaoSuspeitaViewModel> transacoesSuspeitas =
                new List<TransacaoSuspeitaViewModel>
                {

                };
            List<ContaSuspeitaViewModel> contaSuspeitas =
                new List<ContaSuspeitaViewModel>
                {

                };
            List<AgenciaSuspeitaViewModels> agenciaSuspeitas =
                new List<AgenciaSuspeitaViewModels>
                {

                };
            var analise = new AnaliseViewModel(transacoesSuspeitas,
                contaSuspeitas, agenciaSuspeitas);
            List<AnaliseViewModel> analises = new List<AnaliseViewModel>();
            analises.Add(analise);

            foreach (var transferencia in transferencias)
            {

                var ValorMaximoParaContaSuspeita = 1000000.00;
                var ValorMaximoParaAgenciaSuspeita = 1000000000.00;
                DateTime dataDaTransacao = DateTime.Parse(transferencia.Data);
                DateTime dataParaAnalize = DateTime.Parse(data);

                if (dataDaTransacao.Month == dataParaAnalize.Month
                    && dataDaTransacao.Year == dataParaAnalize.Year)
                {
                    double ValorEmDouble = double.Parse(transferencia.Valor);
                    double SomaDosValoresDoMesConta = 0;
                    double SomaDosValoresDoMesAgencia = 0;

                    var conta = transferencias.Select(x => x.ContaDestino);
                    var agencia = transferencias.Select(x => x.AgenciaDestino);
                    if (transferencia.Valor.Length >= 9)
                    {
                        transacoesSuspeitas.Add(new TransacaoSuspeitaViewModel
                        {
                            BancoOrigem = transferencia.BancoOrigem,
                            AgenciaOrigem = transferencia.AgenciaOrigem,
                            ContaOrigem = transferencia.ContaOrigem,
                            BancoDestino = transferencia.BancoDestino,
                            AgenciaDestino = transferencia.AgenciaDestino,
                            ContaDestino = transferencia.ContaDestino,
                            Valor = transferencia.Valor

                        }
                            );
                    }
                    foreach (var item in conta)
                    {
                        if (item.Equals(transferencia.ContaDestino))
                        {
                            SomaDosValoresDoMesConta += ValorEmDouble;
                        }
                    }
                    if (SomaDosValoresDoMesConta >= ValorMaximoParaContaSuspeita)
                    {
                        var contaJaESuspeita = contaSuspeitas.Where(x => x.ContaDestino.Equals(transferencia.ContaDestino)).Any();

                        if (!contaJaESuspeita)
                        {
                            contaSuspeitas.Add(new ContaSuspeitaViewModel
                            {
                                BancoDestino = transferencia.BancoDestino,
                                AgenciaDestino = transferencia.AgenciaDestino,
                                ContaDestino = transferencia.ContaDestino,
                                ValorMovimentado = SomaDosValoresDoMesConta.ToString(),
                                TipoMovimentacao = "Entrada"

                            });
                        }

                    }
                    foreach (var item in agencia)
                    {
                        if (item.Equals(transferencia.AgenciaDestino))
                        {
                            SomaDosValoresDoMesAgencia += ValorEmDouble;
                        }
                    }
                    if (SomaDosValoresDoMesAgencia >= ValorMaximoParaAgenciaSuspeita)
                    {
                        var agenciaJaESuspeita = agenciaSuspeitas.Where(
                            d => d.AgenciaDestino.Equals(transferencia.AgenciaDestino)).Any();
                        if (!agenciaJaESuspeita)
                        {
                            agenciaSuspeitas.Add(new AgenciaSuspeitaViewModels
                            {
                                BancoDestino = transferencia.BancoDestino,
                                AgenciaDestino = transferencia.AgenciaDestino,
                                ValorMovimentado = SomaDosValoresDoMesAgencia.ToString(),
                                TipoMovimentacao = "Entrada"

                            });
                        }
                    }
                }

            }
            return View(analises);
        }

    }
}
