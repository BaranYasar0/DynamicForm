using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DynamicForm.Api.Application.Features.Rules;
using DynamicForm.Api.Application.Helpers.Authorization;
using DynamicForm.Api.Application.Services;
using DynamicForm.Api.Application.Services.Interfaces;
using DynamicForm.Api.Application.Utilities.Authorization;
using DynamicForm.Api.Application.Utilities.Pipelines;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DynamicForm.Api.Application.Extensions
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,IConfiguration configuration)
        {

            services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<AuthBusinessRules>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));

            services.AddScoped<IAuthService, AuthService>();
            services.AddSingleton<ITokenHelper, TokenHelper>();
            services.AddScoped<IUserService, UserService>();

            //services.Configure<TokenOptions>(x =>
            //{
            //    configuration.GetSection("TokenOptions");
            //});

            return services;
        }
    }
}
