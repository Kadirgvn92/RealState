using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RealState.Entity;
using RealState.Repository.GenericRepository;
using RealState.Repository.IRepository;
using RealState.ViewModels.BuyerViewModels;
using RealState.ViewModels.NotificationViewModels;
using RealState.ViewModels.QuestViewModels;

namespace RealState.Controllers;
public class QuestController : Controller
{
    private readonly IQuestRepository _questRepository;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IStatusRepository _statusRepository;
    private readonly ITypeRepository _typeRepository;
    private readonly INotificationRepository _notificationRepository;

    public QuestController(IQuestRepository questRepository, IUserService userService, IMapper mapper, ICategoryRepository categoryRepository, IStatusRepository statusRepository, ITypeRepository typeRepository, INotificationRepository notificationRepository)
    {
        _questRepository = questRepository;
        _userService = userService;
        _mapper = mapper;
        _categoryRepository = categoryRepository;
        _statusRepository = statusRepository;
        _typeRepository = typeRepository;
        _notificationRepository = notificationRepository;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public IActionResult CreateQuest()
    {
       
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

        ViewBag.CategoryList = categorList;
        ViewBag.TypeList = typeList;
        ViewBag.StatusList = statusList;

        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateQuest(CreateQuestViewModel model)
    {
        var user = await _userService.GetUserByUsernameAsync();
        var quest = _mapper.Map<Quest>(model);

        quest.CreatedDate = quest.CreatedDate.ToUniversalTime();
        quest.AppUserID = user.AppUserID;

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        _questRepository.Insert(quest);

        var notModel = new CreateNotificationViewModel
        {
            Title = "Yeni Arayış Eklendi",
            QuestID = quest.QuestID,
            Message = $"{quest.Title} - {quest.Price} arayış {user.FirstName} {user.LastName} tarafından eklendi.",
            CreatedDate = DateTime.UtcNow,
            IsRead = false,
        };

        var notification = _mapper.Map<Notification>(notModel);

        _notificationRepository.Insert(notification);

        TempData["SuccessMessage"] = "Kayıt başarılı şekilde gerçekleşti.";

        return RedirectToAction("CreateQuest");
    }
    public IActionResult CardQuest()
    {
        var quests = _questRepository.GetAllQuestsWithFeatures();

        var questDtos = quests.Select(q => new ResultQuestViewModel
        {
            QuestID = q.QuestID,
            Title = q.Title,
            Price = q.Price,
            AddressLine = q.AddressLine,
            Latitude = q.Latitude,
            Longtitude = q.Longtitude,
            CreatedDate = q.CreatedDate,
            RealEstateTypeName = q.RealEstateType.TypeName,
            RealEstateCategoryName = q.RealEstateCategory.CategoryName,
            RealEstateStatusName = q.RealEstateStatus.StatusName
        }).ToList();
        return View(questDtos);
    }

    [HttpGet]
    public IActionResult GetQuest()
    {

        var quests = _questRepository.GetAllQuestsWithFeatures();

        var questDtos = quests.Select(q => new ResultQuestViewModel
        {
            QuestID = q.QuestID,
            Title = q.Title,
            Price = q.Price,
            AddressLine = q.AddressLine,
            Latitude = q.Latitude,
            Longtitude = q.Longtitude,
            CreatedDate = q.CreatedDate,
            RealEstateTypeName = q.RealEstateType.TypeName,
            RealEstateCategoryName = q.RealEstateCategory.CategoryName,
            RealEstateStatusName = q.RealEstateStatus.StatusName
        }).ToList();

        var data = JsonConvert.SerializeObject(questDtos);

        return Content(data, "application/json");
    }
}
