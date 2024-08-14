using Microsoft.AspNetCore.Mvc;
using RealState.Entity;
using RealState.JWTools;
using RealState.Repository.IRepository;
using RealState.ViewModels.AuthViewModels;
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
                    // Kullanıcı bilgilerini claim olarak ekleyin
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Role, user.Role)
                    };

                    var token = _tokenGenerator.GenerateToken(new GetCheckAppUserViewModel
                    {
                        Username = user.Username,
                        Role = user.Role
                    });

                    ViewBag.Token = token;

                    return RedirectToAction("Index", "Dashboard"); 
                }

                ModelState.AddModelError("", "Geçersiz kullanıcı adı veya şifre.");
            }

            return View(model);
        }
    }
}
