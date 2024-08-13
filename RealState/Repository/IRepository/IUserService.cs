using RealState.Entity;

namespace RealState.Repository.IRepository;

public interface IUserService
{
    Task<AppUser> AuthenticateUserAsync(string username, string password);
    Task<AppUser> RegisterUserAsync(string username, string password);
    Task<IEnumerable<AppRole>> GetRolesAsync();
}