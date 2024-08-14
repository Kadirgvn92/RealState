using Microsoft.AspNetCore.Mvc;
using RealState.Entity;
using RealState.JWTools;
using RealState.Repository.IRepository;
using System.Data;
using System.Security.Claims;

public class _NavbarPartial : ViewComponent
{
    private readonly IUserService _userService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public _NavbarPartial(IHttpContextAccessor httpContextAccessor, IUserService userService)
    {
        _httpContextAccessor = httpContextAccessor;
        _userService = userService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var userClaims = _httpContextAccessor.HttpContext.User.Claims;

        var username = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
        var Role = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

        var value = _userService.GetUserByUsernameAsync(username);

        return View();

    }
}
