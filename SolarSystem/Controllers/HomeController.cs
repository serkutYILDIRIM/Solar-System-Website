using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLog;
using SolarSystem.ViewModels;
using SolarSystem.Data.Models;

namespace SolarSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;


        public HomeController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index(int? planetId)
        {
            ViewBag.PlanetId = planetId;
            return View();
        }
        public IActionResult SolarSystem()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View(new LoginModel());
        }
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var signInResult = _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false).Result;

                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                ModelState.AddModelError("", "username or password is wrong");
            }

            return View(model);
        }
        public IActionResult Sun()
        {
            return View();
        }
        public IActionResult NotFound(int code)
        {
            ViewBag.Code = code;

            return View();
        }
        [Route("/Error")]
        public IActionResult Error()
        {
            var errorInfo = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var logger = LogManager.GetLogger("FileLogger");
            logger.Log(LogLevel.Error, $"\nThe Error Occurred Here:{errorInfo.Path} \nError Message: {errorInfo.Error.Message}\nStackTrace:{errorInfo.Error.StackTrace}");

            return View();
        }
    }
}
