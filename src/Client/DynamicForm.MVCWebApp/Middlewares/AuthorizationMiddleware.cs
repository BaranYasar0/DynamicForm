using Microsoft.AspNetCore.Authentication;

namespace DynamicForm.MVCWebApp.Middlewares
{
    public class AuthorizationMiddleware
    {
        //private readonly IHttpContextAccessor _httpContextAccessor;

        //public AuthorizationMiddleware(IHttpContextAccessor httpContextAccessor)
        //{
        //    _httpContextAccessor = httpContextAccessor;
        //}

        //public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        //{
        //    // Kullanıcı kimliğini doğrulayın
        //    var result = await context.AuthenticateAsync();

        //    if (result.Succeeded)
        //    {
        //        // Eğer kullanıcı doğrulanırsa, bir sonraki middleware'e devredin
        //        await next(context);
        //    }
        //    else
        //    {
        //        // Kullanıcı doğrulanamazsa, giriş sayfasına yönlendirin
        //        context.Response.Redirect("/Auth/Login");
        //    }
        //}
    }
}
