using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealState.Repository.IRepository;

namespace RealState.Controllers;
public class FSBOController : Controller
{
    private readonly IFSBORepository _fSBORepository;

    public FSBOController(IFSBORepository fSBORepository)
    {
        _fSBORepository = fSBORepository;
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
}
