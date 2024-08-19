using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealState.Entity;
using RealState.Models;
using RealState.Repository.GenericRepository;
using RealState.Repository.IRepository;
using RealState.ViewModels.AuthViewModels;
using RealState.ViewModels.BuyerViewModels;
using RealState.ViewModels.NotificationViewModels;
using System.Security.Claims;

namespace RealState.Controllers;
public class BuyerController : Controller
{
    private readonly IBuyerRepository _buyerRepository;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;
    private readonly INotificationRepository _notificationRepository;
    public BuyerController(IBuyerRepository BuyerRepository, IMapper mapper, IUserService userService, INotificationRepository notificationRepository)
    {
        _buyerRepository = BuyerRepository;
        _mapper = mapper;
        _userService = userService;
        _notificationRepository = notificationRepository;
    }
    public IActionResult Index()
    {
        var values = _buyerRepository.GetAll();
        return View(values);
    }
    [HttpGet]
    public IActionResult CreateBuyer()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateBuyerAsync(CreateBuyerViewModel model)
    {
        var user = await _userService.GetUserByUsernameAsync();

        var buyer = _mapper.Map<Buyer>(model);

        buyer.CreatedDate = buyer.CreatedDate.ToUniversalTime();
        buyer.AppUserID = user.AppUserID; 

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        _buyerRepository.Insert(buyer);

        var notModel = new CreateNotificationViewModel
        {
            Title = "Yeni Alıcı Eklendi",
            BuyerID = buyer.BuyerID,
            Message = $"{buyer.FirstName} {buyer.LastName} isimli alıcı {user.FirstName} {user.LastName} tarafından eklendi.",
            CreatedDate = DateTime.UtcNow,
            IsRead = false,
        };

        var notification = _mapper.Map<Notification>(notModel);

        _notificationRepository.Insert(notification);

       
        

        TempData["SuccessMessage"] = "Kayıt başarılı şekilde gerçekleşti.";

        return RedirectToAction("CreateBuyer");
    }

    [HttpGet]
    public async Task<IActionResult> GetBuyer()
    {

        var buyers = _buyerRepository.GetAll();

        var data = JsonConvert.SerializeObject(buyers);

        return Content(data, "application/json");
    }
}
