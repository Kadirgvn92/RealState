using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealState.Repository.GenericRepository;
using RealState.Repository.IRepository;
using RealState.ViewModels.QuestViewModels;

namespace RealState.Controllers;
public class QuestController : Controller
{
    private readonly IQuestRepository _questRepository;

    public QuestController(IQuestRepository questRepository)
    {
        _questRepository = questRepository;
    }

    public IActionResult Index()
    {
        return View();
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
