using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace SolarSystem.ViewModels
{
    public class CreateRecentNewsModel
    {
        [Required(ErrorMessage = "News name is required")]
        public string NewsName { get; set; }
        [Required(ErrorMessage = "News subject is required")]
        public string NewsSubject { get; set; }
        [Required(ErrorMessage = "News content is required")]
        public string NewsContent { get; set; }
        [Required(ErrorMessage = "Picture is required")]
        public IFormFile Picture { get; set; }
    }
}
