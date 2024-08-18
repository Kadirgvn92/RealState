using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RealState.Entity;
using RealState.Repository.IRepository;
using RealState.ViewModels.SellerViewModels;

namespace RealState.Controllers;
public class SellerController : Controller
{
    private readonly ISellerRepository _sellerRepository;
    private readonly IMapper _mapper;

    public SellerController(ISellerRepository sellerRepository, IMapper mapper)
    {
        _sellerRepository = sellerRepository;
        _mapper = mapper;
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
    public IActionResult CreateSeller(CreateSellerViewModel model)
    {

        var seller = _mapper.Map<Seller>(model);

        seller.ListingDate = seller.ListingDate.ToUniversalTime();

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        _sellerRepository.Insert(seller);

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
