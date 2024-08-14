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
}
