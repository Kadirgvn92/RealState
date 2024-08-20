using Microsoft.AspNetCore.Mvc;
using RealState.Repository.IRepository;

namespace RealState.Controllers;
public class NotificationController : Controller
{
    private readonly INotificationRepository _notificationRepository;

    public NotificationController(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    public IActionResult Index()
    {
        return View();
    }
}
