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

        // Kayıt sayfasını gösterir
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // Kayıt işlemini yapar
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
                    return RedirectToAction("Login"); // Kayıttan sonra giriş sayfasına yönlendir
                }

                ModelState.AddModelError("", "Kayıt başarısız.");
            }

            return View(model);
        }

        // Giriş sayfasını gösterir
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Giriş işlemini yapar

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

        //[HttpPost]
        //public async Task<IActionResult> Login(LoginViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await _userService.AuthenticateUserAsync(model.Username, model.Password);

        //        if (user != null)
        //        {
        //            // Kullanıcı bilgilerini claim olarak ekleyin
        //            var claims = new List<Claim>
        //            {
        //                new Claim(ClaimTypes.Name, user.Username),
        //                new Claim(ClaimTypes.Role, user.RoleID.ToString())
        //            };

        //            var tokenGenerated = _tokenGenerator.GenerateToken(new GetCheckAppUserViewModel
        //            {
        //                Username = user.Username,
        //                RoleID = user.RoleID
        //            });
        //            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
        //            var token = handler.ReadJwtToken(tokenGenerated.Token);
        //            var claims2 = token.Claims.ToList();
        //            if(tokenGenerated.Token != null)
        //            {
        //                claims.Add(new Claim("accessToken", tokenGenerated.Token));
        //                var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
        //                var authProps = new AuthenticationProperties
        //                {
        //                    ExpiresUtc = tokenGenerated.ExpireDate,
        //                    IsPersistent = true
        //                };

        //                await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);

        //                return RedirectToAction("Index", "Dashboard");
        //            }

        //        }

        //        ModelState.AddModelError("", "Geçersiz kullanıcı adı veya şifre.");
        //    }

        //    return View(model);
        //}
    }
}
