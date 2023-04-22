using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForm.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynamicForm.Infrastructure.Persistance.EntityConfigurations
{
    public class FormEntityConfiguration:BaseEntityConfiguration<Form>
    {
        public override void Configure(EntityTypeBuilder<Form> builder)
        {
            builder.HasMany(x => x.Fields);

            base.Configure(builder);
        }
    }
}
