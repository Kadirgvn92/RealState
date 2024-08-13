using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealState.Entity;
using RealState.Repository.IRepository;
using RealState.ViewModels.BuyerViewModels;

namespace RealState.Controllers;
public class BuyerController : Controller
{
    private readonly IBuyerRepository _buyerRepository;
    private readonly IMapper _mapper;

    public BuyerController(IBuyerRepository BuyerRepository, IMapper mapper)
    {
        _buyerRepository = BuyerRepository;
        _mapper = mapper;
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
    public IActionResult CreateBuyer(CreateBuyerViewModel model)
    {

        var Buyer = _mapper.Map<Buyer>(model);

        Buyer.CreatedDate = Buyer.CreatedDate.ToUniversalTime();

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        _buyerRepository.Insert(Buyer);

        TempData["SuccessMessage"] = "Kayıt başarılı şekilde gerçekleşti.";

        return RedirectToAction("CreateBuyer");
    }

    [HttpGet]
    public IActionResult GetBuyer()
    {
       
        var Buyers = _buyerRepository.GetAll();

        var data = JsonConvert.SerializeObject(Buyers);

        return Content(data, "application/json");
    }
}
