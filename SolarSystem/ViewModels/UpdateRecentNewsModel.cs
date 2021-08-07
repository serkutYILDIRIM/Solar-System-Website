using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace SolarSystem.ViewModels
{
    public class UpdateRecentNewsModel
    {
        public int NewsId { get; set; }
        [Required(ErrorMessage = "News name is required")]
        public string NewsName { get; set; }
        [Required(ErrorMessage = "News subject is required")]
        public string NewsSubject { get; set; }
        [Required(ErrorMessage = "News content is required")]
        public string NewsContent { get; set; }
        public IFormFile Picture { get; set; }
    }
}
