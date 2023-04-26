using DynamicForm.MVCWebApp.Services.Intrerfaces;
using Microsoft.AspNetCore.Mvc;

namespace DynamicForm.MVCWebApp.Controllers
{
    public class FormController : Controller
    {
        private readonly IFormService _formService;

        public FormController(IFormService formService)
        {
            _formService = formService;
        }

        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Auth");
            return View(await _formService.GetFormList());
        }

        public async Task<IActionResult> GetFormsByUserId()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Auth");
            return View(await _formService.GetFormsByUserId());
        }

        public IActionResult CreateForm()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Auth");
            return View();
        }
    }
}
