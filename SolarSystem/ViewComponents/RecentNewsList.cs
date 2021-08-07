using Microsoft.AspNetCore.Mvc;
using SolarSystem.Service.Interfaces;

namespace SolarSystem.ViewComponents
{
    public class RecentNewsList : ViewComponent
    {
        private readonly IRecentNewsService _recentNewsService;
        public RecentNewsList(IRecentNewsService recentNewsService)
        {
            _recentNewsService = recentNewsService;
        }
        public IViewComponentResult Invoke()
        {
            return View(_recentNewsService.ListAll());
        }
    }
}
