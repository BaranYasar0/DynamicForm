using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForm.Api.Application.Repositories;
using DynamicForm.Api.Domain.Entities;
using DynamicForm.Infrastructure.Persistance.Context;

namespace DynamicForm.Infrastructure.Persistance.Repositories
{
    public class UserOperationClaimRepository:BaseRepository<UserOperationClaim>, IUserOperationClaimRepository
    {
        public UserOperationClaimRepository(BaseDbContext context) : base(context)
        {
        }
    }

}
