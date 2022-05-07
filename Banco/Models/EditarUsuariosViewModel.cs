using Microsoft.AspNetCore.Identity;

namespace Banco.Models
{
    public class EditarUsuariosViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public List<UsuarioFuncaoViewModel> Funcoes { get; set; }
        public EditarUsuariosViewModel()
        {
                
        }
        public EditarUsuariosViewModel(RoleManager<IdentityRole>roleManager,
            string id, string email)
        {
            Id = id;
            Email = email;
            Funcoes = roleManager.Roles.ToList().Select(funcao =>
            new UsuarioFuncaoViewModel
            {
                Nome = funcao.Name,
                Id = funcao.Id
            }).ToList();
            foreach (var funcao in Funcoes)
            {
                var funcaoUsuario = roleManager.Roles.Any(usuarioRole =>
                usuarioRole.Id == funcao.Id);
                funcao.Selecionado = funcaoUsuario;
            }
           
        }
    }
}
