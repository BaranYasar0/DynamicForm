using DynamicForm.MVCWebApp.Models.Inputs;
using DynamicForm.MVCWebApp.Models.ViewModels;

namespace DynamicForm.MVCWebApp.Services.Intrerfaces
{
    public interface IAuthService
    {
        public Task<string> GetTokenAsync(LoginInput input);
        public Task<bool> Register(RegisterViewModel model);

    }
}
