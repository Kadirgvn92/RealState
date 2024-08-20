using RealState.Context;
using RealState.Entity;
using RealState.Repository.IRepository;

namespace RealState.Repository.GenericRepository;

public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
{
    public NotificationRepository(RealStateContext db) : base(db)
    {
    }
    private RealStateContext context => (RealStateContext)_context;
    public List<Notification> GetLast10Notifications()
    {
       var values = context.Notifications.OrderByDescending(x => x.NotificationID).Take(10).ToList(); 
        return values;
    }
}
