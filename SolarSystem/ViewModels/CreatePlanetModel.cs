using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace SolarSystem.ViewModels
{
    public class CreatePlanetModel
    {
        [Required(ErrorMessage = "Planet name is required")]
        public string PlanetName { get; set; }
        [Required(ErrorMessage = "Distance to Sun is required")]
        public string DistanceToSun { get; set; }
        [Required(ErrorMessage = "One way light time to Sun is required")]
        public string OneWayLightTimeToSun { get; set; }
        [Required(ErrorMessage = "Length of year is required")]
        public string LengthOfYear { get; set; }
        [Required(ErrorMessage = "Planet type is required")]
        public string PlanetType { get; set; }
        [Required(ErrorMessage = "Planet info is required")]
        public string PlanetInfo { get; set; }
        [Required(ErrorMessage = "Picture is required")]
        public IFormFile Picture { get; set; }
    }
}
