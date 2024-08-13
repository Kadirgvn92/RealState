using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealState.Entity;
using RealState.Repository.IRepository;
using RealState.ViewModels.PortfolioViewModels;

namespace RealState.Controllers;
public class PortfolioController : Controller
{
    private readonly IPortfolioRepository _portfolioRepository;
    private readonly IMapper _mapper;

    public PortfolioController(IPortfolioRepository portfolioRepository, IMapper mapper)
    {
        _portfolioRepository = portfolioRepository;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public IActionResult CreatePortfolio()
    {
        return View();
    }
    [HttpPost]
    public IActionResult CreatePortfolio(CreatePortfolioViewModel model)
    {

        var portfolio = _mapper.Map<Portfolio>(model);

        portfolio.CreatedDate = portfolio.CreatedDate.ToUniversalTime();

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        _portfolioRepository.Insert(portfolio);

        TempData["SuccessMessage"] = "Kayıt başarılı şekilde gerçekleşti.";

        return RedirectToAction("CreatePortfolio");
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
