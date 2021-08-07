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
    public class RecentNewsController : Controller
    {
        private readonly IRecentNewsService _recentNewsService;

        public RecentNewsController(IRecentNewsService recentNewsService)
        {
            _recentNewsService = recentNewsService;
        }
        public IActionResult Index()
        {
            return View(_recentNewsService.ListAll());
        }
        public IActionResult Create()
        {
            return View(new CreateRecentNewsModel());
        }
        [HttpPost]
        public IActionResult Create(CreateRecentNewsModel model)
        {
            if (ModelState.IsValid)
            {
                RecentNews recentNews = new RecentNews();
                if (model.Picture != null)
                {
                    var extension = Path.GetExtension(model.Picture.FileName);
                    var newImgName = Guid.NewGuid() + extension;

                    var placeToLoad = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/crudImg/" + newImgName);

                    var stream = new FileStream(placeToLoad, FileMode.Create);
                    model.Picture.CopyTo(stream);

                    recentNews.Picture = newImgName;
                }

                recentNews.NewsName = model.NewsName;
                recentNews.NewsSubject = model.NewsSubject;
                recentNews.NewsContent = model.NewsContent;

                _recentNewsService.Create(recentNews);

                return RedirectToAction("Index", "RecentNews", new { area = "Admin" });
            }
            return View(model);
        }
        public IActionResult Update(int id)
        {
            var getNews = _recentNewsService.ListWithId(id);

            UpdateRecentNewsModel model = new UpdateRecentNewsModel
            {
                NewsName = getNews.NewsName,
                NewsSubject = getNews.NewsSubject,
                NewsContent = getNews.NewsContent,
                NewsId = getNews.NewsId
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(UpdateRecentNewsModel model)
        {
            if (ModelState.IsValid)
            {
                var newsWillUpdated = _recentNewsService.ListWithId(model.NewsId);
                if (model.Picture != null)
                {
                    var extension = Path.GetExtension(model.Picture.FileName);
                    var newImgName = Guid.NewGuid() + extension;

                    var placeToLoad = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/crudImg/" + newImgName);

                    var stream = new FileStream(placeToLoad, FileMode.Create);
                    model.Picture.CopyTo(stream);

                    newsWillUpdated.Picture = newImgName;
                }

                newsWillUpdated.NewsName = model.NewsName;
                newsWillUpdated.NewsSubject = model.NewsSubject;
                newsWillUpdated.NewsContent = model.NewsContent;

                _recentNewsService.Update(newsWillUpdated);

                return RedirectToAction("Index", "RecentNews", new { area = "Admin" });
            }
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            _recentNewsService.Delete(new RecentNews { NewsId = id });

            return RedirectToAction("Index");
        }
    }
}
