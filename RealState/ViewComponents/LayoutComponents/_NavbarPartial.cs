using Microsoft.AspNetCore.Mvc;

namespace RealState.ViewComponents.LayoutComponents;

public class _NavbarPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
