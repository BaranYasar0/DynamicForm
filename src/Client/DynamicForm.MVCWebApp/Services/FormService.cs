using DynamicForm.MVCWebApp.Models.ViewModels.Forms;
using DynamicForm.MVCWebApp.Services.Intrerfaces;

namespace DynamicForm.MVCWebApp.Services
{
    public class FormService:IFormService
    {
        private readonly HttpClient _httpClient;

        public FormService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<GetFormListViewModel>> GetFormList()
        {
            var response=await _httpClient.GetAsync("https://localhost:7038/api/form");
            if (!response.IsSuccessStatusCode)
                return null;

            var successReponse = await response.Content.ReadFromJsonAsync<List<GetFormListViewModel>>();
            return successReponse;
        }
    }
}
