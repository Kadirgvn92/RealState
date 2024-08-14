namespace RealState.Entity;

public class AppRole
{
    public int AppRoleId { get; set; }
    public string RoleName { get; set; }
    public List<AppUser> AppUsers { get; set; }
}
