using RealState.Repository.IRepository;

namespace RealState.Entity;

public class Buyer : ISoftDeletable
{
    public int BuyerID { get; set; }
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Budget { get; set; } 
    public string? PreferredLocation { get; set; } 
    public string? Description { get; set; } 
    public string? Rooms { get; set; }
    public List<Portfolio> Portfolios { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsDeleted { get; set; }
}
