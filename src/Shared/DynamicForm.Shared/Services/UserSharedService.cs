using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DynamicForm.Shared.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace DynamicForm.Shared.Services
{
    public class UserSharedService:IUserSharedService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public UserSharedService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public async Task<int> GetUserIdFromToken()
        {
            return Convert.ToInt32(_contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
    }
}
