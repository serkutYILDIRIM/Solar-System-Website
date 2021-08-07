using Microsoft.AspNetCore.Mvc;
using SolarSystem.Service.Interfaces;

namespace SolarSystem.Controllers
{
    public class PlanetController : Controller
    {
        private readonly IPlanetService _planetService;
        public PlanetController(IPlanetService planetService)
        {
            _planetService = planetService;
        }
        public IActionResult PlanetDetail(int id)
        {
            return View(_planetService.ListWithId(id));
        }
    }
}
