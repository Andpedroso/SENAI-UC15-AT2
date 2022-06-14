using System.ComponentModel.DataAnnotations;

namespace SENAI_UC14_AT2.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "E-mail Requerido")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Senha Requerida")]
        public string Senha { get; set; }
    }
}
