using RealState.Repository.IRepository;
using System.Text.Json.Serialization;

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
    public DateTime CreatedDate { get; set; }
    public int AppUserID { get; set; }
    [JsonIgnore]
    public AppUser AppUser { get; set; }
    public bool IsDeleted { get; set; }
    public List<Notification> Notifications { get; set; }
}
