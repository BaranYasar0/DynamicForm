using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DynamicForm.MVCWebApp.Models.Inputs;
using DynamicForm.MVCWebApp.Models.ViewModels;
using DynamicForm.MVCWebApp.Services.Intrerfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;

namespace DynamicForm.MVCWebApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthController(IAuthService authService, HttpClient httpClient, IHttpContextAccessor contextAccessor)
        {
            _authService = authService;
            _httpClient = httpClient;
            _contextAccessor = contextAccessor;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginInput model)
        {
            var token = await _authService.GetTokenAsync(model);
            if (!string.IsNullOrEmpty(token))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "form@form.com",
                    ValidAudience = "form@form.com",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("strongandsecretkeystrongandsecretkey"))
                };

                var principal = tokenHandler.ValidateToken(token, validationParameters, out var _);
                //HttpContext.Session.SetString("token", token);
                Response.Cookies.Append("token",token,new CookieOptions()
                {
                    Expires = DateTime.Now.AddHours(1),
                    Secure = true
                });


                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
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

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
    }
}
