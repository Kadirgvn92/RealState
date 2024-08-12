using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealState.DTOs.CustomerDTOs;
using RealState.Entity;
using RealState.Repository.IRepository;

namespace RealState.Controllers;
public class CustomerController : Controller
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomerController(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        var values = _customerRepository.GetAll();
        return View(values);
    }
    [HttpGet]
    public IActionResult CustomerAdd()
    {
        return View();
    }
    [HttpPost]
    public IActionResult CustomerAdd(CustomerAddDTO dTO)
    {
        
        var customer = _mapper.Map<Customer>(dTO);

        customer.ListingDate = customer.ListingDate?.ToUniversalTime();
        customer.FSBODate = customer.FSBODate?.ToUniversalTime();
        customer.NextCallDate = customer.NextCallDate?.ToUniversalTime();

        if (!ModelState.IsValid)
        {
            return View(dTO); 
        }

        _customerRepository.Insert(customer);

        TempData["SuccessMessage"] = "Kayıt başarılı şekilde gerçekleşti.";

        return RedirectToAction("CustomerAdd");
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
