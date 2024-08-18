using Microsoft.EntityFrameworkCore;
using RealState.Context;
using RealState.Entity;
using RealState.Repository.IRepository;

namespace RealState.Repository.GenericRepository;

public class AddressRepository : GenericRepository<RealEstateAddress>, IAddressRepository
{
    public AddressRepository(RealStateContext db) : base(db)
    {
    }
}
