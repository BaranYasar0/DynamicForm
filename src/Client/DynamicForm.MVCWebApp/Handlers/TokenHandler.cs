using System.Net.Http.Headers;
using DynamicForm.MVCWebApp.Services.Intrerfaces;

namespace DynamicForm.MVCWebApp.Handlers
{
    public class TokenHandler:DelegatingHandler
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IAuthService _authService;

        public TokenHandler(IHttpContextAccessor contextAccessor, IAuthService authService)
        {
            _contextAccessor = contextAccessor;
            _authService = authService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string token = _contextAccessor.HttpContext.Request.Cookies["token"];
            
            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization= new AuthenticationHeaderValue("Bearer", token);
                
                var response= await base.SendAsync(request, cancellationToken);
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    throw new Exception("Yetkin Yok!");
            }
            
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
