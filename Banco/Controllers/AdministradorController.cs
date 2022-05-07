using Banco.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Banco.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdministradorController : Controller
    {
        UserManager<IdentityUser> userManager;
        RoleManager<IdentityRole> roleManager;

        public AdministradorController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public ActionResult Index()
        {
            var usuarios = userManager.Users.ToList().Select(usuario => new UsuarioViewModel
            {
                Id = usuario.Id,
                Email = usuario.Email,

            });
            return View(usuarios);
        }
        public ActionResult EditarUsuario(string id)
        {
            var usuario = userManager.Users.Where(d => d.Id == id).FirstOrDefault();
            if (usuario == null) { return View("Error"); }
            var modelo = new EditarUsuariosViewModel(roleManager, usuario.Id, usuario.Email);

            return View(modelo);
        }

        [HttpPost]
        public async Task<IActionResult> EditarFuncoes(EditarUsuariosViewModel modelo)
        {
            
                var usuario = await userManager.FindByIdAsync(modelo.Id);
                var rolesUsuario = await userManager.GetRolesAsync(usuario);

                var resultadoRemocao = await userManager.RemoveFromRolesAsync(
                    usuario,
                     rolesUsuario.ToArray());

                if (resultadoRemocao.Succeeded)
                {
                    var funcoesSelecionadasPeloAdmin = modelo.Funcoes
                        .Where(funcao => funcao.Selecionado)
                        .Select(funcao => funcao.Nome).ToArray();
                    var resultadoAdicao = await userManager.AddToRolesAsync(
                        usuario, funcoesSelecionadasPeloAdmin);
                    if (resultadoAdicao.Succeeded)
                    {
                        return RedirectToAction("Index", "Administrador");
                    }
                }
            
            return View();
        }



    }
}

