using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealState.Entity;
using RealState.Repository.GenericRepository;
using RealState.Repository.IRepository;
using RealState.ViewModels.FSBOViewModels;
using RealState.ViewModels.NotificationViewModels;

namespace RealState.Controllers;
public class FSBOController : Controller
{
    private readonly IFSBORepository _fSBORepository;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly INotificationRepository _notificationRepository;

    public FSBOController(IFSBORepository fSBORepository, IUserService userService, IMapper mapper, INotificationRepository notificationRepository)
    {
        _fSBORepository = fSBORepository;
        _userService = userService;
        _mapper = mapper;
        _notificationRepository = notificationRepository;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public IActionResult GetFSBO()
    {

        var fSBOs = _fSBORepository.GetAll();

        var data = JsonConvert.SerializeObject(fSBOs);

        return Content(data, "application/json");
    }
    [HttpGet]
    public IActionResult CreateFSBO()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateFSBO(CreateFSBOViewModel model)
    {
        var user = await _userService.GetUserByUsernameAsync();
        var FSBOs = _mapper.Map<FSBO>(model);

        FSBOs.CreatedDate = DateTime.Now.ToUniversalTime();
        FSBOs.AppUserID = user.AppUserID;

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        _fSBORepository.Insert(FSBOs);


        var notModel = new CreateNotificationViewModel
        {
            Title = "Yeni FSBO Kaydı Eklendi",
            FSBOId = FSBOs.FSBOId,
            Message = $"{FSBOs.ListingNumber} ilan numaralı {FSBOs.PhoneNumber} numaraya sahip FSBO kaydı {user.FirstName} {user.LastName} tarafından gerçekleştirildi.",
            CreatedDate = DateTime.UtcNow,
            IsRead = false,
        };

        var notification = _mapper.Map<Notification>(notModel);

        _notificationRepository.Insert(notification);

        TempData["SuccessMessage"] = "Kayıt başarılı şekilde gerçekleşti.";

        return RedirectToAction("CreateFSBO");
    }
}
