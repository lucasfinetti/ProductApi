using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProdutosTeste.Application.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [DisplayName("Nome")]
        public string Username { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [DisplayName("Senha")]
        public string Password { get; set; }
    }
}
