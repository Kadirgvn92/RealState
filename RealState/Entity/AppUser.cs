using System.Text.Json.Serialization;

namespace RealState.Entity;

public class AppUser
{
    public int AppUserID { get; set; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Mail { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; }
    public int RoleID { get; set; }
    public AppRole AppRole { get; set; }
    public string? ImageUrl { get; set; }
    public string? Title { get; set; }
    public List<Buyer> Buyers { get; set; }
    public List<CalendarEvent> CalendarEvents { get; set; }
    public List<FSBO> FSBOs { get; set; }
    public List<Portfolio> Portfolios { get; set; }
    public List<Quest> Quests { get; set; }
    public List<Seller> Sellers { get; set; }
}
