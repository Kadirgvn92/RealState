﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealState.Entity;
using RealState.Models;
using RealState.Repository.GenericRepository;
using RealState.Repository.IRepository;
using System.Security.Claims;

namespace RealState.Controllers;
public class CalendarController : Controller
{
    private readonly ICalendarRepository _calendarRepository;
    private readonly IUserService _userService;

    public CalendarController(ICalendarRepository calendarRepository, IUserService userService)
    {
        _calendarRepository = calendarRepository;
        _userService = userService;
    }

    public IActionResult Index()
    {
        return View();
    }
    public DateTime ConvertUtcToLocal(DateTime utcDate)
    {
        TimeZoneInfo turkeyTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time");
        return TimeZoneInfo.ConvertTimeFromUtc(utcDate, turkeyTimeZone);
    }
    [HttpGet]
    public async Task<IActionResult> GetEvents()
    {


        var events = _calendarRepository.GetAll()
            .Select(e => new
            {
                id = e.Id,
                title = e.Title,
                start = e.StartDate,
                end = e.EndDate.HasValue ? e.EndDate : null,
                description = e.Description,
                venue = e.Venue,
                className = e.ClassName,
            })
            .ToList();

        return Ok(events);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CalendarEvent calendarEvent)
    {
        if (ModelState.IsValid)
        {
            calendarEvent.StartDate = DateTime.SpecifyKind(calendarEvent.StartDate, DateTimeKind.Utc);
            calendarEvent.EndDate = calendarEvent.EndDate.HasValue
                ? DateTime.SpecifyKind(calendarEvent.EndDate.Value, DateTimeKind.Utc)
                : (DateTime?)null;

            var user = await _userService.GetUserByUsernameAsync();
            calendarEvent.AppUserID = user.AppUserID;


            _calendarRepository.Insert(calendarEvent);
            return Json(new { success = true, message = "Program başarıyla oluşturuldu." });
        }
        return Json(new { success = false, message = "Program yüklemede hata meydana geldi." });
    }
    // POST: /Calendar/Remove
    [HttpPost]
    public async Task<IActionResult> Remove(int id)
    {
        if (id != null)
        {
            _calendarRepository.Delete(id);
            return Json(new { success = true, message = "Event removed successfully." });
        }
        return Json(new { success = false, message = "Failed to update event." });
    }

    // POST: /Calendar/Update
    [HttpPost]
    public async Task<IActionResult> Update(CalendarEvent calendarEvent)
    {
        if (ModelState.IsValid)
        {
            _calendarRepository.Update(calendarEvent);
            return Json(new { success = true, message = "Event updated successfully." });
        }
        return Json(new { success = false, message = "Failed to update event." });
    }
}
