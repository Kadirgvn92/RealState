using Microsoft.EntityFrameworkCore;
using RealState.Entity;

namespace RealState.Context;

public class RealStateContext : DbContext
{
    public RealStateContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Drawing> Drawings { get; set; }
    public DbSet<Buyer> Buyers { get; set; }
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<Portfolio> Portfolios { get; set; }
    public DbSet<RealEstateAddress> RealEstateAddresses { get; set; }
    public DbSet<RealEstateCategory> RealEstateCategories { get; set; }
    public DbSet<RealEstateType> RealEstateTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Bire bir ilişkiyi yapılandırma
        modelBuilder.Entity<Portfolio>()
            .HasOne(p => p.RealEstateAddress)
            .WithOne(r => r.Portfolio)
            .HasForeignKey<Portfolio>(p => p.RealEstateAddressID);
    }
}
