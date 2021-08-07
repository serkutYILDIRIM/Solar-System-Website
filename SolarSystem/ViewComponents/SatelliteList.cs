using Microsoft.AspNetCore.Mvc;
using SolarSystem.Service.Interfaces;

namespace SolarSystem.ViewComponents
{
    public class SatelliteList :ViewComponent
    {
        private readonly ISatelliteService _satelliteService;
        public SatelliteList(ISatelliteService satelliteService)
        {
            _satelliteService = satelliteService;
        }
        public IViewComponentResult Invoke(int? planetId)
        {
            if (planetId.HasValue)
            {
                return View(_satelliteService.ListWithPlanetId((int)planetId));
            }

            return View(_satelliteService.ListAll());
        }
    }
}
