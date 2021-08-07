using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using SolarSystem.Service.Interfaces;

namespace SolarSystem.Controllers
{
    public class SatelliteController : Controller
    {
        private readonly ISatelliteService _satelliteService;
        public SatelliteController(ISatelliteService satelliteService)
        {
            _satelliteService = satelliteService;
        }
        public IActionResult SatelliteDetail(int id)
        {
            string data = "";
            int planetId = 0;
            var planets = _satelliteService.PlanetInfo(id).Select(I => I.PlanetId);
            foreach (var item in planets)
            {
                data += item + " ";
            }
            Int32.TryParse(data, out planetId);
            ViewBag.PlanetId = planetId;

            string image = "";
            var planetImage = _satelliteService.PlanetImg(id).Select(I => I.Picture);
            foreach (var item in planetImage)
            {
                image += item + " ";
            }
            ViewBag.PlanetImage = image;

            return View(_satelliteService.ListWithId(id));
        }
    }
}
