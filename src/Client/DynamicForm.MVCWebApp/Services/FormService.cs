using DynamicForm.MVCWebApp.Models.ViewModels.Forms;
using DynamicForm.MVCWebApp.Services.Intrerfaces;
using DynamicForm.Shared.Services.Interfaces;

namespace DynamicForm.MVCWebApp.Services
{
    public class FormService:IFormService
    {
        private readonly HttpClient _httpClient;
        private readonly IUserSharedService _userSharedService;

        public FormService(HttpClient httpClient, IUserSharedService userSharedService)
        {
            _httpClient = httpClient;
            _userSharedService = userSharedService;
        }

        public async Task<List<GetFormListViewModel>> GetFormList()
        {
            var response=await _httpClient.GetAsync("https://localhost:7038/api/form");
            if (!response.IsSuccessStatusCode)
                return null;

            var successReponse = await response.Content.ReadFromJsonAsync<List<GetFormListViewModel>>();
            return successReponse;
        }

        public async Task<List<GetFormListViewModel>> GetFormsByUserId()
        {
            var response = await _httpClient.GetAsync("api/Form/GetByUserId");
            if (!response.IsSuccessStatusCode)
                return null;

            var successReponse = await response.Content.ReadFromJsonAsync<List<GetFormListViewModel>>();
            return successReponse;
        }
    }
}
