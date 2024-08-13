namespace RealState.Entity;

public class AppUser
{
    public int AppUserID { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; }
}
