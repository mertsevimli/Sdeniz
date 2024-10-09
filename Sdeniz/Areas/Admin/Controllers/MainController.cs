using Microsoft.AspNetCore.Mvc;

namespace Sdeniz.Areas.Admin.Controllers;

public class MainController : Controller
{
    [Area("Admin")]
    // GET
    public IActionResult Index()
    {
        return View();
    }
}