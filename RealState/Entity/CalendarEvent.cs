namespace RealState.Entity;

using RealState.Repository.IRepository;
using System;

public class CalendarEvent : ISoftDeletable
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool AllDay { get; set; } = true;
    public string? Description { get; set; }
    public string? Venue { get; set; }
    public string? ClassName { get; set; }

    public bool IsDeleted { get; set; }
    // Foreign Key
    public int? PortfolioID { get; set; }
    public Portfolio Portfolio { get; set; } 
}
