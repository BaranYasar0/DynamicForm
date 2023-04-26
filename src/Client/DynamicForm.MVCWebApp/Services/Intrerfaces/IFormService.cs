using DynamicForm.MVCWebApp.Models.ViewModels.Forms;

namespace DynamicForm.MVCWebApp.Services.Intrerfaces
{
    public interface IFormService
    {
        public Task<List<GetFormListViewModel>> GetFormList();
        public Task<List<GetFormListViewModel>> GetFormsByUserId();

    }
}
