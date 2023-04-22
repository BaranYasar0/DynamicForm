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
    public class FieldEntityConfiguration:BaseEntityConfiguration<Field>
    {
        public override void Configure(EntityTypeBuilder<Field> builder)
        {
            builder.Property(x => x.Name)
                .HasColumnName("F_Name");

            builder.Property(x => x.Required)
                .HasColumnName("F_Req");

            builder.Property(x => x.DataType)
                .IsRequired()
                .HasColumnName("F_Type");

            base.Configure(builder);
        }
    }
}
