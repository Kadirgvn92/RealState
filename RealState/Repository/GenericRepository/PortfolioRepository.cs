using Microsoft.EntityFrameworkCore;
using RealState.Context;
using RealState.Entity;
using RealState.Repository.IRepository;

namespace RealState.Repository.GenericRepository;

public class PortfolioRepository : GenericRepository<Portfolio>, IPortfolioRepository
{
    public PortfolioRepository(RealStateContext db) : base(db)
    {
    }
    private RealStateContext context => (RealStateContext)_context;
    public List<Portfolio> GetAllPortfoliosWithFeatures()
    {
        var values = context.Portfolios.Include(x => x.RealEstateAddress).Include(x => x.Seller).Include(x => x.RealEstateType).Include(x => x.RealEstateCategory).Include(x => x.RealEstateStatus).ToList();
        return values;
    }
}
