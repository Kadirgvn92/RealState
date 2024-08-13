using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using RealState.Context;
using RealState.Entity;
using RealState.ViewModels;
using System.Text.Json.Nodes;

namespace RealState.Controllers;
public class MapController : Controller
{
    private readonly RealStateContext _context;

    public MapController(RealStateContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var values = _context.Drawings.ToList();
        return View(values);
    }

    [HttpPost]
    public IActionResult SaveGeoJson([FromBody] JsonObject geoJsonData)
    {
        var reader = new GeoJsonReader();
        var geometry = reader.Read<Geometry>(geoJsonData.ToString());
        // Convert the relevant part of the JsonNode to a Geometry object
        var drawing = new Drawing
        {
            Type = geoJsonData["type"].ToString(),
            Geometry = geometry
        };


        _context.Drawings.Add(drawing);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult GetGeo()
    {
        var values = _context.Drawings.ToList();


        return View(values);
    }

    public IActionResult DeleteGeo(int id)
    {
        var values = _context.Drawings.Find(id);
        if (values != null)
        {
            _context.Drawings.Remove(values);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult UpdateGeo(int id)
    {
        var values = _context.Drawings.Find(id);
        var model = new UpdateDrawingViewModel()
        {
            DrawingId = values.DrawingId,
            Name = values.Name,
            Type = values.Type,
            Description = values.Description,
        };
        return View(model);
    }
    [HttpPost]
    public IActionResult UpdateGeo(UpdateDrawingViewModel model)
    {
        var values = _context.Drawings.Find(model.DrawingId);

        if (values != null)
        {
            values.Name = model.Name;
            values.Description = model.Description;
            values.Type = model.Type;
            _context.Update(values);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        return View(model);
    }
}
