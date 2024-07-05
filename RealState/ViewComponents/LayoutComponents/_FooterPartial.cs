using Microsoft.AspNetCore.Mvc;

namespace RealState.ViewComponents.LayoutComponents;

public class _FooterPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
