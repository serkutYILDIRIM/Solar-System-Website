using Microsoft.AspNetCore.Mvc;
using SolarSystem.Service.Interfaces;

namespace SolarSystem.Areas.Admin.ViewComponents
{
    public class AdminRecentNewsList : ViewComponent
    {
        private readonly IRecentNewsService _recentNewsService;
        public AdminRecentNewsList(IRecentNewsService recentNewsService)
        {
            _recentNewsService = recentNewsService;
        }
        public IViewComponentResult Invoke()
        {
            return View(_recentNewsService.ListAll());
        }
    }
}
