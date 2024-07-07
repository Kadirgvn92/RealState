using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealState.Repository.IRepository;

namespace RealState.Controllers;
public class CustomerController : Controller
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerController(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public IActionResult Index()
    {
        var values = _customerRepository.GetAll();
        return View(values);
    }

    [HttpGet]
    public IActionResult GetCustomer()
    {
        // Comment nesnelerini al
        var comments = _customerRepository.GetAll();
        // Comment nesnelerini JSON formatına dönüştür
        var jsonComments = JsonConvert.SerializeObject(comments);
        // JSON formatındaki Comment nesnelerini View'e gönder
        return Content(jsonComments, "application/json");
    }
}
