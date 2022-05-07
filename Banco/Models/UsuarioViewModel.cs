namespace Banco.Models
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel()
        {

        }
        public UsuarioViewModel(string id, string email)
        {
            Id = id;
            Email = email;
        }

        public string Id { get; set; }
        public string Email { get; set; }
    }
}
