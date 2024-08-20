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
        var values = _notificationRepository.GetLast10Notifications();
        var count = values.Count;
        ViewBag.Count = count;  
        return View(values);
    }
}
