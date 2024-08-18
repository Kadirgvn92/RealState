using RealState.Entity;

namespace RealState.Repository.IRepository;

public interface IQuestRepository : IRepository<Quest>
{
    List<Quest> GetAllQuestsWithFeatures();
}
