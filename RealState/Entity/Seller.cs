using RealState.Repository.IRepository;

namespace RealState.Entity;

public class Seller : ISoftDeletable
{
    public int SellerID { get; set; }
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? PropertyTitle { get; set; } 
    public string? AskingPrice { get; set; } 
    public string? Description { get; set; } 
    public DateTime ListingDate { get; set; } 
    public List<Portfolio> Portfolios { get; set; }
    public int AppUserID { get; set; }
    public AppUser AppUser { get; set; }
    public bool IsDeleted { get; set; }


}
