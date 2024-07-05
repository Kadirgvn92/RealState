using Microsoft.AspNetCore.Mvc;

namespace RealState.ViewComponents.LayoutComponents;

public class _HeadPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
