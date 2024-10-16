using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Sdeniz.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MainController : Controller
    {
        // GET: Admin/Main
        public IActionResult Index()
        {
            return View();
        }
    }
}
