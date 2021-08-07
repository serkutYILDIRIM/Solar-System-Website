using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolarSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SolarSystem.Data.Models;
using SolarSystem.Service.Interfaces;

namespace SolarSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PlanetController : Controller
    {
        private readonly IPlanetService _planetService;
        private readonly ISatelliteService _satelliteService;

        public PlanetController(IPlanetService planetService, ISatelliteService satelliteService)
        {
            _planetService = planetService;
            _satelliteService = satelliteService;
        }
        public IActionResult Index()
        {
            return View(_planetService.ListAll());
        }
        public IActionResult Create()
        {

            return View(new CreatePlanetModel());
        }
        [HttpPost]
        public IActionResult Create(CreatePlanetModel model)
        {
            if (ModelState.IsValid)
            {
                Planet planet = new Planet();
                if (model.Picture != null)
                {
                    var extension = Path.GetExtension(model.Picture.FileName);
                    var newImgName = Guid.NewGuid() + extension;

                    var placeToLoad = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/crudImg/" + newImgName);

                    var stream = new FileStream(placeToLoad, FileMode.Create);
                    model.Picture.CopyTo(stream);

                    planet.Picture = newImgName;
                }

                planet.PlanetName = model.PlanetName;
                planet.DistanceToSun = model.DistanceToSun;
                planet.OneWayLightTimeToSun = model.OneWayLightTimeToSun;
                planet.LengthOfYear = model.LengthOfYear;
                planet.PlanetType = model.PlanetType;
                planet.PlanetInfo = model.PlanetInfo;

                _planetService.Create(planet);

                return RedirectToAction("Index", "Planet", new { area = "Admin" });
            }
            return View(model);
        }
        public IActionResult Update(int id)
        {
            var getPlanet = _planetService.ListWithId(id);

            UpdatePlanetModel model = new UpdatePlanetModel
            {
                PlanetName = getPlanet.PlanetName,
                DistanceToSun = getPlanet.DistanceToSun,
                OneWayLightTimeToSun = getPlanet.OneWayLightTimeToSun,
                LengthOfYear = getPlanet.LengthOfYear,
                PlanetType =getPlanet.PlanetType,
                PlanetInfo = getPlanet.PlanetInfo,
                PlanetId = getPlanet.PlanetId
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(UpdatePlanetModel model)
        {
            if (ModelState.IsValid)
            {
                var planetWillUpdated = _planetService.ListWithId(model.PlanetId);
                if (model.Picture != null)
                {
                    var extension = Path.GetExtension(model.Picture.FileName);
                    var newImgName = Guid.NewGuid() + extension;

                    var placeToLoad = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/crudImg/" + newImgName);

                    var stream = new FileStream(placeToLoad, FileMode.Create);
                    model.Picture.CopyTo(stream);

                    planetWillUpdated.Picture = newImgName;
                }

                planetWillUpdated.PlanetName = model.PlanetName;
                planetWillUpdated.DistanceToSun = model.DistanceToSun;
                planetWillUpdated.OneWayLightTimeToSun = model.OneWayLightTimeToSun;
                planetWillUpdated.LengthOfYear = model.LengthOfYear;
                planetWillUpdated.PlanetType = model.PlanetType;
                planetWillUpdated.PlanetInfo = model.PlanetInfo;

                _planetService.Update(planetWillUpdated);

                return RedirectToAction("Index", "Planet", new { area = "Admin" });
            }
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            _planetService.Delete(new Planet { PlanetId = id });

            return RedirectToAction("Index");
        }
        public IActionResult AddSatellite(int id)
        {
            var planetsWithSatellites = _planetService.ListSatellites(id).Select(I => I.SatelliteName);
            var satellites = _satelliteService.ListAll();

            TempData["PlanetId"] = id;

            List<SatelliteAddModel> list = new List<SatelliteAddModel>();

            foreach (var item in satellites)
            {
                SatelliteAddModel model = new SatelliteAddModel();
                model.SatelliteId = item.SatelliteId;
                model.SatelliteName = item.SatelliteName;
                model.IsExists = planetsWithSatellites.Contains(item.SatelliteName);

                list.Add(model);
            }

            return View(list);
        }
        [HttpPost]
        public IActionResult AddSatellite(List<SatelliteAddModel> list)
        {
            int planetId = (int)TempData["PlanetId"];
            foreach (var item in list)
            {
                if (item.IsExists)
                {
                    _planetService.AddSatellite(new PlanetSatellite
                    {
                        SatelliteId = item.SatelliteId,
                        PlanetId = planetId
                    });
                }
                else
                {
                    _planetService.DeleteSatellite(new PlanetSatellite
                    {
                        SatelliteId = item.SatelliteId,
                        PlanetId = planetId
                    });
                }
            }

            return RedirectToAction("Index");
        }
    }
}
