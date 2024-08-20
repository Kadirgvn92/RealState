using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RealState.Entity;
using RealState.Repository.GenericRepository;
using RealState.Repository.IRepository;
using RealState.ViewModels.NotificationViewModels;
using RealState.ViewModels.SellerViewModels;

namespace RealState.Controllers;
public class SellerController : Controller
{
    private readonly ISellerRepository _sellerRepository;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;
    private readonly INotificationRepository _notificationRepository;

    public SellerController(ISellerRepository sellerRepository, IMapper mapper, IUserService userService, INotificationRepository notificationRepository)
    {
        _sellerRepository = sellerRepository;
        _mapper = mapper;
        _userService = userService;
        _notificationRepository = notificationRepository;
    }

    public IActionResult Index()
    {
        var values = _sellerRepository.GetAll();
       
        return View(values);
    }
    [HttpGet]
    public IActionResult CreateSeller()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateSeller(CreateSellerViewModel model)
    {
        var user = await _userService.GetUserByUsernameAsync();
        var seller = _mapper.Map<Seller>(model);

        seller.ListingDate = seller.ListingDate.ToUniversalTime();
        seller.AppUserID = user.AppUserID;
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        _sellerRepository.Insert(seller);

        var notModel = new CreateNotificationViewModel
        {
            Title = "Yeni Mülk Sahibi Eklendi",
            SellerID = seller.SellerID,
            Message = $"{seller.FirstName} {seller.LastName} isimli mülk sahibi {user.FirstName} {user.LastName} tarafından eklendi.",
            CreatedDate = DateTime.UtcNow,
            IsRead = false,
        };

        var notification = _mapper.Map<Notification>(notModel);

        _notificationRepository.Insert(notification);

        TempData["SuccessMessage"] = "Kayıt başarılı şekilde gerçekleşti.";

        return RedirectToAction("CreateSeller");
    }

    [HttpGet]
    public IActionResult GetSeller()
    {

        var sellers = _sellerRepository.GetAll();

        var data = JsonConvert.SerializeObject(sellers);

        return Content(data, "application/json");
    }
}
