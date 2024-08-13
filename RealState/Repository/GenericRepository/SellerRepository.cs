using RealState.Context;
using RealState.Entity;
using RealState.Repository.IRepository;

namespace RealState.Repository.GenericRepository;

public class SellerRepository : GenericRepository<Seller>, ISellerRepository
{
    public SellerRepository(RealStateContext db) : base(db)
    {
    }
}
