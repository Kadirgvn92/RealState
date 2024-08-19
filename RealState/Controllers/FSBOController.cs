using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealState.Entity;
using RealState.Repository.GenericRepository;
using RealState.Repository.IRepository;
using RealState.ViewModels.BuyerViewModels;
using RealState.ViewModels.FSBOViewModels;

namespace RealState.Controllers;
public class FSBOController : Controller
{
    private readonly IFSBORepository _fSBORepository;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public FSBOController(IFSBORepository fSBORepository, IUserService userService, IMapper mapper)
    {
        _fSBORepository = fSBORepository;
        _userService = userService;
        _mapper = mapper;
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

        TempData["SuccessMessage"] = "Kayıt başarılı şekilde gerçekleşti.";

        return RedirectToAction("CreateFSBO");
    }
}
