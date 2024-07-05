using Microsoft.AspNetCore.Mvc;

namespace RealState.ViewComponents.LayoutComponents;

public class _HeaderPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
