using Microsoft.AspNetCore.Mvc;
using SolarSystem.Service.Interfaces;

namespace SolarSystem.Areas.Admin.ViewComponents
{
    public class AdminPlanetList : ViewComponent
    {
        private readonly IPlanetService _planetService;
        public AdminPlanetList(IPlanetService planetService)
        {
            _planetService = planetService;
        }
        public IViewComponentResult Invoke()
        {
            return View(_planetService.ListAll());
        }
    }
}
