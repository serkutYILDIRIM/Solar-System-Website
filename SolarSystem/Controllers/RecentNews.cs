using Microsoft.AspNetCore.Mvc;
using SolarSystem.Service.Interfaces;

namespace SolarSystem.Controllers
{
    public class RecentNews : Controller
    {
        private readonly IRecentNewsService _recentNewsService;
        public RecentNews(IRecentNewsService recentNewsService)
        {
            _recentNewsService = recentNewsService;
        }
        public IActionResult RecentNewsDetail(int id)
        {
            return View(_recentNewsService.ListWithId(id));
        }
    }
}
