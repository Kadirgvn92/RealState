using RealState.Context;
using RealState.Entity;
using RealState.Repository.IRepository;

namespace RealState.Repository.GenericRepository;

public class CalendarRepository : GenericRepository<CalendarEvent>, ICalendarRepository
{
    public CalendarRepository(RealStateContext db) : base(db)
    {
    }
}
