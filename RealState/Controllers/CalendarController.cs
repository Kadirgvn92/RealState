using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealState.Entity;
using RealState.Repository.IRepository;

namespace RealState.Controllers;
public class CalendarController : Controller
{
    private readonly ICalendarRepository _calendarRepository;

    public CalendarController(ICalendarRepository calendarRepository)
    {
        _calendarRepository = calendarRepository;
    }

    public IActionResult Index()
    {
        return View();
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

            _calendarRepository.Insert(calendarEvent);
            return Json(new { success = true, message = "Program başarıyla oluşturuldu." });
        }
        return Json(new { success = false, message = "Program yüklemede hata meydana geldi." });
    }
    // POST: /Calendar/Remove
    [HttpPost]
    public async Task<IActionResult> Remove(int id)
    {
        if(id != null)
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
