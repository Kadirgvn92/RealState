using Microsoft.AspNetCore.Mvc;

namespace RealState.ViewComponents.LayoutComponents;

public class _OffCanvasPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
