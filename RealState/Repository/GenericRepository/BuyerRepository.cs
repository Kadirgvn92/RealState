using Microsoft.EntityFrameworkCore;
using RealState.Context;
using RealState.Entity;
using RealState.Models;
using RealState.Repository.IRepository;

namespace RealState.Repository.GenericRepository;

public class BuyerRepository : GenericRepository<Buyer>, IBuyerRepository
{
    public BuyerRepository(RealStateContext db) : base(db)
    {
    }
    private RealStateContext context => (RealStateContext)_context;

    public List<Buyer> GetAllByUser(int id)
    {
        return context.Buyers.Where(x => x.AppUserID == id && !x.IsDeleted).ToList();
    }

}
