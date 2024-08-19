using Microsoft.AspNetCore.Mvc;
using RealState.Repository.IRepository;

namespace RealState.ViewComponents.LayoutComponents;

public class _HeaderPartial : ViewComponent
{
    private readonly INotificationRepository _notificationRepository;

    public _HeaderPartial(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    public IViewComponentResult Invoke()
    {
        

        return View();
    }
}
