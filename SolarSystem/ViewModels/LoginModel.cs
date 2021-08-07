using System.ComponentModel.DataAnnotations;

namespace SolarSystem.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username Cannot Be Null")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password Cannot Be Null")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
