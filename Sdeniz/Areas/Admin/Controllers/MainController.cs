using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Sdeniz.Areas.Admin.Controllers;

public class MainController : Controller
{
    [Area("Admin"), Authorize]
    // GET
    public IActionResult Index()
    {
        return View();
    }
}