using DynamicForm.MVCWebApp.Models.Inputs;
using DynamicForm.MVCWebApp.Models.ViewModels;
using DynamicForm.MVCWebApp.Services.Intrerfaces;
using Newtonsoft.Json.Linq;

namespace DynamicForm.MVCWebApp.Services
{
    public class AuthService:IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetTokenAsync(LoginInput input)
        {
            //_httpClient.BaseAddress = new Uri("https://localhost:7038/");

            var response = await _httpClient.PostAsJsonAsync("api/Auth/login", input);

            if (response.IsSuccessStatusCode)
            {
                var result=await response.Content.ReadAsStringAsync();
                var tokenObject = JObject.Parse(result)["accessToken"];
                var token = tokenObject.Value<string>("token");
                return token;
            }

            return null;
        }

        public async Task<bool> Register(RegisterViewModel model)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Auth/Register", model);

            if (response.IsSuccessStatusCode)
                return true;

            return false;

        }
    }
}
