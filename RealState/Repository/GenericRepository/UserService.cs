
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RealState.Context;
using RealState.Entity;
using RealState.Repository.IRepository;
using RealState.ViewModels.AuthViewModels;

namespace RealState.Repository.GenericRepository;

public class UserService : IUserService
{
    private readonly RealStateContext _context;
    private readonly IPasswordHasher<AppUser> _passwordHasher;

    public UserService(RealStateContext context, IPasswordHasher<AppUser> passwordHasher)
    {
        _context = context;
        _passwordHasher = passwordHasher;
    }

    public async Task<AppUser> AuthenticateUserAsync(string username, string password)
    {
        // Kullanıcıyı kullanıcı adı ile veritabanından al
        var user = await _context.AppUsers.SingleOrDefaultAsync(u => u.Username == username);

        // Kullanıcı bulunamadıysa null döndür
        if (user == null)
        {
            return null;
        }

        // Şifre doğrulaması yap
        var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);

        // Şifre doğrulama sonucu başarısızsa null döndür
        if (passwordVerificationResult != PasswordVerificationResult.Success)
        {
            return null;
        }

        // Şifre doğrulaması başarılıysa kullanıcıyı döndür
        return user;
    }

    public async Task<AppUser> RegisterUserAsync(RegisterViewModel model)
    {
        var hashedPassword = _passwordHasher.HashPassword(null, model.Password);
        var user = new AppUser
        {
            Username = model.Username,
            FirstName = model.FirstName,
            LastName = model.LastName,
            PhoneNumber = model.PhoneNumber,
            Mail = model.Mail,
            PasswordHash = hashedPassword,
            Role = "User" // Varsayılan rol
        };

        _context.AppUsers.Add(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<IEnumerable<AppRole>> GetRolesAsync()
    {
        return await _context.AppRoles.ToListAsync();
    }
}