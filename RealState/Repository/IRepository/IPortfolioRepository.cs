using RealState.Entity;

namespace RealState.Repository.IRepository;

public interface IPortfolioRepository : IRepository<Portfolio>
{
    List<Portfolio> GetAllPortfoliosWithFeatures();
}
