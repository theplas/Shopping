using System.ComponentModel.DataAnnotations;

namespace Shopping.Models.Login
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
