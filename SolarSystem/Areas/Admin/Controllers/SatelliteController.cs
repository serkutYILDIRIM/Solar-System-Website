using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolarSystem.ViewModels;
using System;
using System.IO;
using SolarSystem.Data.Models;
using SolarSystem.Service.Interfaces;

namespace SolarSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SatelliteController : Controller
    {
        private readonly ISatelliteService _satelliteService;
        public SatelliteController(ISatelliteService satelliteService)
        {
            _satelliteService = satelliteService;
        }
        public IActionResult Index()
        {
            return View(_satelliteService.ListAll());
        }
        public IActionResult Create()
        {

            return View(new CreateSatelliteModel());
        }
        [HttpPost]
        public IActionResult Create(CreateSatelliteModel model)
        {
            if (ModelState.IsValid)
            {
                Satellite satellite = new Satellite();
                if (model.Picture != null)
                {
                    var extension = Path.GetExtension(model.Picture.FileName);
                    var newImgName = Guid.NewGuid() + extension;

                    var placeToLoad = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/crudImg/" + newImgName);

                    var stream = new FileStream(placeToLoad, FileMode.Create);
                    model.Picture.CopyTo(stream);

                    satellite.Picture = newImgName;
                }

                satellite.SatelliteName = model.SatelliteName;
                satellite.SatelliteInfo = model.SatelliteInfo;

                _satelliteService.Create(satellite);

                return RedirectToAction("Index", "Satellite", new { area = "Admin" });
            }
            return View(model);
        }
        public IActionResult Update(int id)
        {
            var getSatellite = _satelliteService.ListWithId(id);

            UpdateSatelliteModel model = new UpdateSatelliteModel
            {
                SatelliteName = getSatellite.SatelliteName,
                SatelliteInfo = getSatellite.SatelliteInfo,
                SatelliteId = getSatellite.SatelliteId
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(UpdateSatelliteModel model)
        {
            if (ModelState.IsValid)
            {
                var satelliteWillUpdated = _satelliteService.ListWithId(model.SatelliteId);
                if (model.Picture != null)
                {
                    var extension = Path.GetExtension(model.Picture.FileName);
                    var newImgName = Guid.NewGuid() + extension;

                    var placeToLoad = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/crudImg/" + newImgName);

                    var stream = new FileStream(placeToLoad, FileMode.Create);
                    model.Picture.CopyTo(stream);

                    satelliteWillUpdated.Picture = newImgName;
                }

                satelliteWillUpdated.SatelliteName = model.SatelliteName;
                satelliteWillUpdated.SatelliteInfo = model.SatelliteInfo;

                _satelliteService.Update(satelliteWillUpdated);

                return RedirectToAction("Index", "Satellite", new { area = "Admin" });
            }
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            _satelliteService.Delete(new Satellite { SatelliteId = id });

            return RedirectToAction("Index");
        }
    }
}
