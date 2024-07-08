using Microsoft.AspNetCore.Mvc;

namespace RealState.ViewComponents.LayoutComponents;

public class _BreadcrumbPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
