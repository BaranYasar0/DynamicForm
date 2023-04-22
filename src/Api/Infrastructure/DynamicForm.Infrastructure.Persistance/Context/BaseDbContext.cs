using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DynamicForm.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DynamicForm.Infrastructure.Persistance.Context
{
    public class BaseDbContext:DbContext
    {
        public BaseDbContext()
        {
            
        }

        public BaseDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.Entity<Form>().OwnsMany(x=>x.Fields);

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
           GenerateDateTime();
           return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
           GenerateDateTime();
           return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public void GenerateDateTime()
        {
            var entities = ChangeTracker.Entries<BaseEntity>();

            foreach (var entity in entities)
            {
                _=entity.State switch
                {
                    EntityState.Added => entity.Entity.CreatedDate = DateTime.Now,
                    EntityState.Modified => entity.Entity.UpdatedDate = DateTime.Now,
                    _ => DateTime.Now

                };
            }
        }
    }
}
