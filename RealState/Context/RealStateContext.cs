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
    public DbSet<CalendarEvent> CalendarEvents { get; set; }
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<Portfolio> Portfolios { get; set; }
    public DbSet<FSBO> FSBOs { get; set; }
    public DbSet<Quest> Quests { get; set; }
    public DbSet<RealEstateAddress> RealEstateAddresses { get; set; }
    public DbSet<RealEstateCategory> RealEstateCategories { get; set; }
    public DbSet<RealEstateType> RealEstateTypes { get; set; }
    public DbSet<RealEstateStatus> RealEstateStatuses { get; set; }
    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<AppRole> AppRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Bire bir ilişkiyi yapılandırma
        modelBuilder.Entity<Portfolio>()
            .HasOne(p => p.RealEstateAddress)
            .WithOne(r => r.Portfolio)
            .HasForeignKey<Portfolio>(p => p.RealEstateAddressID);

        modelBuilder.Entity<AppUser>()
            .HasOne(u => u.AppRole)
            .WithMany(r => r.AppUsers)
            .HasForeignKey(u => u.RoleID)
            .OnDelete(DeleteBehavior.ClientSetNull);

        modelBuilder.Entity<CalendarEvent>()
            .HasOne(ce => ce.Portfolio)
            .WithMany(p => p.CalendarEvents)
            .HasForeignKey(ce => ce.PortfolioID)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}
