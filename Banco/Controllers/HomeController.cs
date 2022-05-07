
using Banco.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Serialization;

namespace Banco.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext context = new ApplicationContext();
        private readonly UserManager<IdentityUser> _userManager;

        private IWebHostEnvironment Environment;
        public HomeController(IWebHostEnvironment _environment, UserManager<IdentityUser> userManager)
        {
            Environment = _environment;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(GetTransferencias());
        }

        [HttpPost]
        [Authorize]
        public IActionResult Index(IFormFile postedFile)
        {
            if (postedFile != null)
            {
                string path = CriaCaminhoUpload();
                string csvData = LerArquivo(postedFile, path);
                UpBancoDados(postedFile, path);
            }

            return View(GetTransferencias());
        }
        public List<Transferencia> GetTransferencias()
        {
            return context.transferencias.ToList();
        }
        public Transferencia UpBancoDados(IFormFile postedFile, string path)
        {

            Transferencia transferencia = new Transferencia();
            string fileName = Path.GetFileName(postedFile.FileName);
            string filePath = Path.Combine(path, fileName);
            string extensaoDoArquivo = Path.GetExtension(postedFile.FileName);
            transferencia.DataImportacao = DateTime.Now;
            transferencia.UsuarioLogado = _userManager.GetUserName(this.User);
            if (extensaoDoArquivo.Equals(".csv"))
            {
                CsvParaLista(transferencia, filePath);
                return transferencia;
            }
            if (extensaoDoArquivo.Equals(".xml"))
            {
                XmlParaLista(postedFile,path,transferencia);
                
                return transferencia;
            }
            return transferencia;
        }

        private void CsvParaLista(Transferencia transferencia, string filePath)
        {
            string[] csvData = System.IO.File.ReadAllLines(filePath);

            foreach (string csvItem in csvData)
            {
                if (!string.IsNullOrEmpty(csvItem))
                {

                    var csv = csvItem.Split(',');
                    transferencia.BancoOrigem = csv[0];
                    transferencia.AgenciaOrigem = csv[1];
                    transferencia.ContaOrigem = csv[2];
                    transferencia.BancoDestino = csv[3];
                    transferencia.AgenciaDestino = csv[4];
                    transferencia.ContaDestino = csv[5];
                    transferencia.Valor = csv[6];
                    transferencia.Data = csv[7];

                    SalvarTrasferencias(transferencia);
                }

            }
        }

        private Transferencia XmlParaLista(IFormFile postedFile, string path, Transferencia  transferencia)
        {
            string fileName = Path.GetFileName(postedFile.FileName);
            string filePath = Path.Combine(path, fileName);
            var xmlSerialized = new XmlSerializer(typeof(TransferenciaXml));
            TransferenciaXml i = new TransferenciaXml();
            using (Stream reader = new FileStream(filePath, FileMode.Open))
            {
               i = (TransferenciaXml)xmlSerialized.Deserialize(reader);
                foreach (var item in i.Transacao)
                {
                    transferencia.BancoOrigem = item.Origem.Banco;
                    transferencia.AgenciaOrigem= item.Origem.Agencia;
                    transferencia.ContaOrigem = item.Origem.Conta;
                    transferencia.BancoDestino = item.Destino.Banco;
                    transferencia.AgenciaDestino = item.Destino.Agencia;
                    transferencia.ContaDestino = item.Destino.Conta;
                    transferencia.Valor = item.Valor;
                    transferencia.Data = item.Data;
                    SalvarTrasferencias(transferencia);
                }
            }
           return transferencia;
        }

        private void SalvarTrasferencias(Transferencia transferencia)
        {
            context.transferencias
            .Add(new Transferencia(
                transferencia.BancoOrigem,
                transferencia.AgenciaOrigem,
                transferencia.ContaOrigem,
                transferencia.BancoDestino,
                transferencia.AgenciaDestino,
                transferencia.ContaDestino,
                transferencia.Valor,
                transferencia.Data,
                transferencia.DataImportacao,
                transferencia.UsuarioLogado
                )
            );
            context.SaveChanges();
        }

        private static string LerArquivo(IFormFile postedFile, string path)
        {
            string fileName = Path.GetFileName(postedFile.FileName);
            string filePath = Path.Combine(path, fileName);
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                postedFile.CopyTo(stream);
            }
            string csvData = System.IO.File.ReadAllText(filePath);
            return csvData;
        }

        private string CriaCaminhoUpload()
        {
            string path = Path.Combine(this.Environment.WebRootPath, "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path;
        }
    }
}