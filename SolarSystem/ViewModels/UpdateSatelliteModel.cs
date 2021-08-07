using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace SolarSystem.ViewModels
{
    public class UpdateSatelliteModel
    {
        public int SatelliteId { get; set; }
        [Required(ErrorMessage = "Satellite name is required")]
        public string SatelliteName { get; set; }
        [Required(ErrorMessage = "Satellite info is required")]
        public string SatelliteInfo { get; set; }
        public IFormFile Picture { get; set; }
    }
}
