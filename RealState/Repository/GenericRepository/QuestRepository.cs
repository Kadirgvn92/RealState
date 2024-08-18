using Microsoft.EntityFrameworkCore;
using RealState.Context;
using RealState.Entity;
using RealState.Repository.IRepository;

namespace RealState.Repository.GenericRepository;

public class QuestRepository : GenericRepository<Quest>, IQuestRepository
{
    public QuestRepository(RealStateContext db) : base(db)
    {
    }
    private RealStateContext context => (RealStateContext)_context;
    public List<Quest> GetAllQuestsWithFeatures()
    {
        var values = context.Quests.Include(x => x.RealEstateType).Include(x => x.RealEstateCategory).Include(x => x.RealEstateStatus).ToList();
        return values;
    }
}
