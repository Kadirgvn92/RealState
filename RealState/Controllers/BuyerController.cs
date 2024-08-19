using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealState.Entity;
using RealState.Migrations;
using RealState.Models;
using RealState.Repository.GenericRepository;
using RealState.Repository.IRepository;
using RealState.ViewModels.AuthViewModels;
using RealState.ViewModels.BuyerViewModels;
using System.Security.Claims;

namespace RealState.Controllers;
public class BuyerController : Controller
{
    private readonly IBuyerRepository _buyerRepository;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;
    public BuyerController(IBuyerRepository BuyerRepository, IMapper mapper, IUserService userService)
    {
        _buyerRepository = BuyerRepository;
        _mapper = mapper;
        _userService = userService;
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
        var Buyer = _mapper.Map<Buyer>(model);

        Buyer.CreatedDate = Buyer.CreatedDate.ToUniversalTime();
        Buyer.AppUserID = user.AppUserID; 

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        _buyerRepository.Insert(Buyer);

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
