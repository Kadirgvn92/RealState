using Microsoft.AspNetCore.Mvc;

namespace RealState.Controllers;
public class MapController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
