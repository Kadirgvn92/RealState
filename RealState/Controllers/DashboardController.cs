using HtmlAgilityPack;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealState.Entity;
using RealState.Repository.IRepository;
using System.Globalization;
using System.Xml;

namespace RealState.Controllers;
public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
