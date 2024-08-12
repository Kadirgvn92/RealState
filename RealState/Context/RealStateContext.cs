using Microsoft.EntityFrameworkCore;
using RealState.Entity;

namespace RealState.Context;

public class RealStateContext : DbContext
{
    public RealStateContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Drawing> Drawings { get; set; }
    public DbSet<Customer> Customers { get; set; }
   

}
