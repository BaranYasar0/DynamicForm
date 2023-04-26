using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Shared.Services.Interfaces
{
    public interface IUserSharedService
    {
        public Task<int> GetUserIdFromToken();
    }
}
