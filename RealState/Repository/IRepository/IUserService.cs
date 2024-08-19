using RealState.Entity;
using RealState.ViewModels.AuthViewModels;

namespace RealState.Repository.IRepository;

public interface IUserService
{
    Task<AppUser> AuthenticateUserAsync(string username, string password);
    Task<AppUser> RegisterUserAsync(RegisterViewModel model);
    Task<IEnumerable<AppRole>> GetRolesAsync();
    Task<AppUser> GetUserByUsernameAsync();
}