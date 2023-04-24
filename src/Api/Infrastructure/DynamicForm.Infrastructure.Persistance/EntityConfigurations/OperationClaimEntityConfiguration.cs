using DynamicForm.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DynamicForm.Infrastructure.Persistance.EntityConfigurations
{
    public class OperationClaimEntityConfiguration : BaseEntityConfiguration<OperationClaim>
    {
        public override void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            builder.Property(x => x.Name)
                .HasColumnName("Op_Name");
        }
    }
}
