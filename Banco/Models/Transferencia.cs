
using Microsoft.AspNetCore.Identity;
using System.Text.RegularExpressions;

namespace Banco
{
    public class Transferencia
    {
        public Transferencia()
        {

        }
        public Transferencia(string bancoOrigem, string agenciaOrigem, string contaOrigem, string bancoDestino, string agenciaDestino, string contaDestino, string valor, string data,DateTime dataImportacao,string usuario)
        {
            string valorFormatado = VerificaValor(valor);

            BancoOrigem = bancoOrigem;
            AgenciaOrigem = agenciaOrigem;
            ContaOrigem = contaOrigem;
            BancoDestino = bancoDestino;
            AgenciaDestino = agenciaDestino;
            ContaDestino = contaDestino;
            Valor = valorFormatado;
            Data = data;
            DataImportacao = dataImportacao;
            UsuarioLogado = usuario;
        }

        private static string VerificaValor(string valor)
        {
            var regex = "(\\.)";
            var valorSemFormatacao = valor;
            var padrao = $"{valorSemFormatacao}.00";
            var valorFormatado = "";
            if (!Regex.IsMatch(valorSemFormatacao, regex))
            {
                valorFormatado = Regex.Replace(valorSemFormatacao, valorSemFormatacao, padrao);
            }
            else
            {
                valorFormatado = valorSemFormatacao;
            }

            return valorFormatado;
        }

        public int Id { get; set; }
        public int UsuarioLogadoId { get; set; }
        public string BancoOrigem { get; set; }
        public string AgenciaOrigem { get; set; }
        public string ContaOrigem { get; set; }
        public string BancoDestino { get; set; }
        public string AgenciaDestino { get; set; }
        public string ContaDestino { get; set; }
        public string Valor { get; set; } 
        public string Data{ get; set; }
        public DateTime DataImportacao { get; set; }
        public string UsuarioLogado { get; set; }
       

    }
}