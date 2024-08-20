using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RealState.Entity;
using RealState.Repository.IRepository;
using RealState.ViewModels.NotificationViewModels;
using RealState.ViewModels.PortfolioViewModels;
using System.Net.NetworkInformation;

namespace RealState.Controllers;
public class PortfolioController : Controller
{
    private readonly IPortfolioRepository _portfolioRepository;
    private readonly IMapper _mapper;
    private readonly ISellerRepository _sellerRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly ITypeRepository _typeRepository;
    private readonly IStatusRepository _statusRepository;
    private readonly IAddressRepository _addressRepository;
    private readonly IUserService _userService;
    private readonly INotificationRepository _notificationRepository;

    public PortfolioController(IPortfolioRepository portfolioRepository, IMapper mapper, ISellerRepository sellerRepository, IAddressRepository addressRepository, ICategoryRepository categoryRepository, ITypeRepository typeRepository, IStatusRepository statusRepository, IUserService userService, INotificationRepository notificationRepository)
    {
        _portfolioRepository = portfolioRepository;
        _mapper = mapper;
        _sellerRepository = sellerRepository;
        _categoryRepository = categoryRepository;
        _typeRepository = typeRepository;
        _statusRepository = statusRepository;
        _addressRepository = addressRepository;
        _userService = userService;
        _notificationRepository = notificationRepository;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public IActionResult CreatePortfolio()
    {
        var values = _sellerRepository.GetAll();
        List<SelectListItem> sellers = (from x in values
                                        select new SelectListItem
                                        {
                                            Text = x.FirstName + " " + x.LastName,
                                            Value = x.SellerID.ToString(),
                                        }).ToList();
        var categories = _categoryRepository.GetAll();
        List<SelectListItem> categorList = (from x in categories
                                            select new SelectListItem
                                        {
                                            Text = x.CategoryName,
                                            Value = x.RealEstateCategoryID.ToString(),
                                        }).ToList();

        var types = _typeRepository.GetAll();
        List<SelectListItem> typeList = (from x in types
                                            select new SelectListItem
                                            {
                                                Text = x.TypeName,
                                                Value = x.RealEstateTypeID.ToString(),
                                            }).ToList();

        var status = _statusRepository.GetAll();
        List<SelectListItem> statusList = (from x in status
                                         select new SelectListItem
                                         {
                                             Text = x.StatusName,
                                             Value = x.RealEstateStatusID.ToString(),
                                         }).ToList();

        ViewBag.SellerList = sellers;
        ViewBag.CategoryList = categorList;
        ViewBag.TypeList = typeList;
        ViewBag.StatusList = statusList;
        
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreatePortfolio(CreatePortfolioViewModel model)
    {
        if (ModelState.IsValid)
        {
            string? coverImageUrl = null;
            if (model.Image != null && model.Image.Length > 0)
            {
                var fileName = Path.GetFileNameWithoutExtension(model.Image.FileName);
                var extension = Path.GetExtension(model.Image.FileName);
                var uniqueFileName = $"{fileName}_{Guid.NewGuid()}{extension}";
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    model.Image.CopyTo(stream);
                }

                coverImageUrl = $"/images/{uniqueFileName}";
            }


            var address = new RealEstateAddress
            {
                Street = model.Street,
                BuildingNumber = model.BuildingNumber,
                ApartmentNumber = model.ApartmentNumber,
                City = model.City,
                District = model.District,
                Neighborhood = model.Neighborhood,
                Description = model.AddressDescription,
                IsDeleted = false
            };
            _addressRepository.Insert(address);

            var user = await _userService.GetUserByUsernameAsync();

            var portfolio = _mapper.Map<Portfolio>(model);

            portfolio.RealEstateAddressID = address.RealEstateAddressID;
            portfolio.CreatedDate = DateTime.UtcNow;
            portfolio.IsAvailable = model.IsAvailable;
            portfolio.IsDeleted = false;
            portfolio.CoverImageUrl = coverImageUrl;
            portfolio.AppUserID = user.AppUserID;

            _portfolioRepository.Insert(portfolio);

            var notModel = new CreateNotificationViewModel
            {
                Title = "Yeni Portföy Eklendi",
                PortfolioID = portfolio.PortfolioID,
                Message = $"{portfolio.Seller.FirstName} {portfolio.Seller.LastName} isimli mülk sahibinde ait {portfolio.RealEstateCategory.CategoryName} - {portfolio.RealEstateStatus.StatusName} - {portfolio.RealEstateType.TypeName} tipinde {portfolio.Seller.AskingPrice} istenilen fiyata sahip portföy  {user.FirstName} {user.LastName} tarafından eklendi.",
                CreatedDate = DateTime.UtcNow,
                IsRead = false,
            };

            var notification = _mapper.Map<Notification>(notModel);

            _notificationRepository.Insert(notification);

            TempData["SuccessMessage"] = "Kayıt başarılı şekilde gerçekleşti.";

            return RedirectToAction("CreatePortfolio");
        }

        return View(model);
    }

    [HttpGet]
    public IActionResult GetPortfolio()
    {
        List<Portfolio> Portfolios = _portfolioRepository.GetAllPortfoliosWithFeatures();
        var settings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };
        string data = JsonConvert.SerializeObject(Portfolios, settings);
        return Content(data, "application/json");
    }
}
