using RealState.Context;
using RealState.Entity;
using RealState.Repository.IRepository;

namespace RealState.Repository.GenericRepository;

public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(RealStateContext db) : base(db)
    {
    }

}
