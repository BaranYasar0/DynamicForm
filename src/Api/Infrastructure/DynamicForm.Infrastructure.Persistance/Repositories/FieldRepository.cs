using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForm.Api.Domain.Entities;
using DynamicForm.Infrastructure.Persistance.Context;

namespace DynamicForm.Infrastructure.Persistance.Repositories
{
    public class FieldRepository:BaseRepository<Field>
    {
        public FieldRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
