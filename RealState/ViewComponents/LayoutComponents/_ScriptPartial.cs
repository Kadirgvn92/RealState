using Microsoft.AspNetCore.Mvc;

namespace RealState.ViewComponents.LayoutComponents;

public class _ScriptPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
