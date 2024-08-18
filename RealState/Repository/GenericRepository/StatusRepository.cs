using RealState.Context;
using RealState.Entity;
using RealState.Repository.IRepository;

namespace RealState.Repository.GenericRepository;

public class StatusRepository : GenericRepository<RealEstateStatus>, IStatusRepository
{
    public StatusRepository(RealStateContext db) : base(db)
    {
    }
}
