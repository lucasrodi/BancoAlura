using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Banco.Controllers
{
    public class DetalheController : Controller
    {
        ApplicationContext _context = new ApplicationContext();
        
        [Authorize]
        public IActionResult Index([FromQuery] int codigo)
        {
            if (_context.transferencias.Where(p => p.Id == codigo).Any())
            {
                var transferencia = _context.transferencias
                        .Where(b => b.Id == codigo)
                        .FirstOrDefault();

                return View(transferencia);
            }
            return View();
        }
      
    }
}
