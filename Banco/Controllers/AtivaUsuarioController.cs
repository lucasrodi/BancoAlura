using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Banco.Controllers
{ 
    public class AtivaContaUsuarioRequest
    {
        public AtivaContaUsuarioRequest(string usuarioId, string codigoDeAtivacao)
        {
            UsuarioId = usuarioId;
            CodigoDeAtivacao = codigoDeAtivacao;
        }
        public AtivaContaUsuarioRequest()
        {

        }

        [Required]
        public string UsuarioId { get; set; }
        [Required]
        public string CodigoDeAtivacao { get; set; }
    }
    public class AtivaContaUsuario: Controller
    {
        public UserManager<IdentityUser> _userManager;

        public AtivaContaUsuario(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
       
       
        public IResult AtivaConta(AtivaContaUsuarioRequest request)
        {
            var identityUser = _userManager.Users.FirstOrDefault(i => i.Id == request.UsuarioId);
            var identityResult = _userManager.ConfirmEmailAsync(identityUser, request.CodigoDeAtivacao).Result;
            if (identityResult.Succeeded)
            {
                return Results.Ok();
            }
            return Results.BadRequest();
        }
        [HttpGet("/AtivaUsuario")]

        public IActionResult index([FromQuery] AtivaContaUsuarioRequest usuario)
        {
            AtivaConta(usuario);
            return View();
        }
    }
}