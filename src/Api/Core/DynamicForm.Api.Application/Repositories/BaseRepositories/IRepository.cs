using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForm.Api.Domain.Entities;

namespace DynamicForm.Api.Application.Repositories.BaseRepositories
{
    public interface IRepository<T>:IAsyncRepository<T>,ISyncRepository<T> where T : BaseEntity
    {
    }
}
