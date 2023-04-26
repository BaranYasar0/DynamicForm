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
            
            return View(await _formService.GetFormList());
        }

        
    }
}
