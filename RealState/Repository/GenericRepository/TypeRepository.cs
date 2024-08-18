using RealState.Context;
using RealState.Entity;
using RealState.Repository.IRepository;

namespace RealState.Repository.GenericRepository;

public class TypeRepository : GenericRepository<RealEstateType> , ITypeRepository
{
    public TypeRepository(RealStateContext db) : base(db)
    {
    }
}
