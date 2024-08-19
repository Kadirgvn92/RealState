using RealState.Context;
using RealState.Entity;
using RealState.Repository.IRepository;

namespace RealState.Repository.GenericRepository;

public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
{
    public NotificationRepository(RealStateContext db) : base(db)
    {
    }
}
