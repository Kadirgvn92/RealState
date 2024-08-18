using RealState.Context;
using RealState.Entity;
using RealState.Repository.IRepository;

namespace RealState.Repository.GenericRepository;

public class CategoryRepository : GenericRepository<RealEstateCategory>, ICategoryRepository
{
    public CategoryRepository(RealStateContext db) : base(db)
    {
    }
}
