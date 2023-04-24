using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForm.Api.Application.Repositories.BaseRepositories;
using DynamicForm.Api.Domain.Entities;

namespace DynamicForm.Api.Application.Repositories
{
    public interface IUserRepository:IRepository<User>
    {
    }
}
