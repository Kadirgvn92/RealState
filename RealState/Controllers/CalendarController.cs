using Microsoft.AspNetCore.Mvc;

namespace RealState.Controllers;
public class CalendarController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
