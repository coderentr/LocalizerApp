using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;

namespace LocalizerApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<HomeController> _localizer;
        public HomeController(IStringLocalizer<HomeController> localizer)
        {
            _localizer = localizer;
        }
        public IActionResult Index()
        {
            var message = _localizer.GetString("Message");
            ViewBag.Message = message;
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Communication()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CultureManagement(string culture, string returnUrl) 
        {
            Response.Cookies.Append("Culture", CookieRequestCultureProvider.MakeCookieValue(
                new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30) });
            //return RedirectToAction(nameof(Index));
            return LocalRedirect(returnUrl);
        }
    }
}
