using System.ComponentModel.DataAnnotations;

namespace MyMovies.Entities
{
    public class Authenticate
    {
        [Display(Name = "Usuário", Order = 1)]
        public string Username { get; set; }

        [Display(Name = "Senha", Order = 2)]
        public string Password { get; set; }
    }
}
