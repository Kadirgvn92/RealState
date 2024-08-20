using RealState.Entity;

namespace RealState.Repository.IRepository;

public interface INotificationRepository : IRepository<Notification>
{
    public List<Notification> GetLast10Notifications();
}
