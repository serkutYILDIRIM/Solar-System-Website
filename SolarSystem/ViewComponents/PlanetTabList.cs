using Microsoft.AspNetCore.Mvc;
using SolarSystem.Service.Interfaces;

namespace SolarSystem.ViewComponents
{
    public class PlanetTabList : ViewComponent
    {
        private readonly IPlanetService _planetService;
        public PlanetTabList(IPlanetService planetService)
        {
            _planetService = planetService;
        }
        public IViewComponentResult Invoke()
        {
            return View(_planetService.ListAll());
        }
    }
}
