using Microsoft.AspNetCore.Mvc;

namespace RealState.Controllers;
public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
