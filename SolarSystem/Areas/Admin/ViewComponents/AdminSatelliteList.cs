using Microsoft.AspNetCore.Mvc;
using SolarSystem.Service.Interfaces;

namespace SolarSystem.Areas.Admin.ViewComponents
{
    public class AdminSatelliteList : ViewComponent
    {
        private readonly ISatelliteService _satelliteService;
        public AdminSatelliteList(ISatelliteService satelliteService)
        {
            _satelliteService = satelliteService;
        }
        public IViewComponentResult Invoke()
        {
            return View(_satelliteService.ListAll());
        }
    }
}
