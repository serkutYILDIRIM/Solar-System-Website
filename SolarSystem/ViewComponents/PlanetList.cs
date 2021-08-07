using Microsoft.AspNetCore.Mvc;
using SolarSystem.Service.Interfaces;

namespace SolarSystem.ViewComponents
{
    public class PlanetList : ViewComponent
    {
        private readonly IPlanetService _planetService;
        public PlanetList(IPlanetService planetService)
        {
            _planetService = planetService;
        }
        public IViewComponentResult Invoke()
        {
            return View(_planetService.ListAll());
        }
    }
}
