using DynamicForm.MVCWebApp.Models.Inputs;
using DynamicForm.MVCWebApp.Models.ViewModels;
using DynamicForm.MVCWebApp.Services.Intrerfaces;
using Microsoft.AspNetCore.Mvc;

namespace DynamicForm.MVCWebApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly HttpClient _httpClient;

        public AuthController(IAuthService authService, HttpClient httpClient)
        {
            _authService = authService;
            _httpClient = httpClient;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginInput model)
        {
            // Token'ı AuthService sınıfı kullanarak al
            var token = await _authService.GetTokenAsync(model);
            if (!string.IsNullOrEmpty(token))
            {
                //HttpContext.Session.SetString("token", token);
                Response.Cookies.Append("token",token,new CookieOptions()
                {
                    Expires = DateTime.Now.AddHours(1),
                    Secure = true
                });
                
                return RedirectToAction("Index", "Form");
            }

            ModelState.AddModelError("", "Geçersiz kullanıcı adı veya şifre.");
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            if(await _authService.Register(model))
            return RedirectToAction("Login", "Auth");

            return View();
        }
    }
}
