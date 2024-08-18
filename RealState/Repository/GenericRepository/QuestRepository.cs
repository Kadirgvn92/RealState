using RealState.Context;
using RealState.Entity;
using RealState.Repository.IRepository;

namespace RealState.Repository.GenericRepository;

public class QuestRepository : GenericRepository<Quest>, IQuestRepository
{
    public QuestRepository(RealStateContext db) : base(db)
    {
    }
}
