using Microsoft.AspNetCore.Mvc;

namespace Sdeniz.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Password()
        {
            return View();
        }
    }
}