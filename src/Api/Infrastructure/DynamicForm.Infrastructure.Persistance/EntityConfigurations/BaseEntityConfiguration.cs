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
    public class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName($"{typeof(T)}_Id");

            builder.Property(x => x.CreatedDate)
                .HasColumnName("C_Date")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.UpdatedDate)
                .HasColumnName("U_Date")
                .ValueGeneratedOnAddOrUpdate();

        }
    }
}
