using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealState.Entity;
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
    public IActionResult CustomerAdd(Customer customer)
    {
        _customerRepository.Insert(customer);
        return View();
    }

    [HttpGet]
    public IActionResult GetCustomer()
    {
        // Comment nesnelerini al
        var customers = _customerRepository.GetAll();
        //// Comment nesnelerini JSON formatına dönüştür
        var data = JsonConvert.SerializeObject(customers);
        // JSON formatındaki Comment nesnelerini View'e gönder
        return Content(data, "application/json");
    }
}
