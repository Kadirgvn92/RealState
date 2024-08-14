using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using RealState.Entity;
using RealState.JWTools;
using RealState.Repository.IRepository;
using RealState.ViewModels.AuthViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RealState.Controllers
{
    public class AuthController : Controller
    {
        private readonly JWTokenGenerator _tokenGenerator;
        private readonly IUserService _userService;

        public AuthController(JWTokenGenerator tokenGenerator, IUserService userService)
        {
            _tokenGenerator = tokenGenerator;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Password != model.ConfirmPassword)
                {
                    ModelState.AddModelError("", "Şifreler uyuşmuyor.");
                    return View(model);
                }

                var result = await _userService.RegisterUserAsync(model);

                if (result != null)
                {
                    return RedirectToAction("Login"); 
                }

                ModelState.AddModelError("", "Kayıt başarısız.");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.AuthenticateUserAsync(model.Username, model.Password);

                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Role, user.Role)
                    };

                    var tokenGenerated = _tokenGenerator.GenerateToken(new GetCheckAppUserViewModel
                    {
                        Username = user.Username,
                        Role = user.Role
                    });

                    if (tokenGenerated.Token != null)
                    {
                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var authProps = new AuthenticationProperties
                        {
                            ExpiresUtc = tokenGenerated.ExpireDate,
                            IsPersistent = true
                        };

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);

                        return RedirectToAction("Index", "Dashboard");
                    }
                }

                ModelState.AddModelError("", "Geçersiz kullanıcı adı veya şifre.");
            }

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Auth");
        }
        
    }
}
