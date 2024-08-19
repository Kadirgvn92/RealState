using Microsoft.AspNetCore.Mvc;
using RealState.Entity;
using RealState.JWTools;
using RealState.Repository.IRepository;
using RealState.ViewModels.AuthViewModels;
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
        var value = await _userService.GetUserByUsernameAsync();

        var model = new UserViewModel
        {
            FirstName = value.FirstName,
            LastName = value.LastName,
            Mail = value.Mail,
            ImageUrl = value.ImageUrl,
            Title = value.Title,
            Role = value.Role,
        };

        return View(model);

    }
}
