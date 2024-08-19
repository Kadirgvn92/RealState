using RealState.Entity;

namespace RealState.Repository.IRepository;

public interface IBuyerRepository : IRepository<Buyer>
{
    public List<Buyer> GetAllByUser(int id);
}
