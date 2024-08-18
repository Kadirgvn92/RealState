using RealState.Context;
using RealState.Entity;
using RealState.Repository.IRepository;

namespace RealState.Repository.GenericRepository;

public class FSBORepository : GenericRepository<FSBO>, IFSBORepository
{
    public FSBORepository(RealStateContext db) : base(db)
    {
    }
}
