using Bogus;
using IOTBartender.Domain.Entititeis;
using IOTBartender.Infrastructure.EFCore.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IOTBartender.Infrastructure.EFCore
{
    public class ApplicationDbContext
        : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FluidEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RecipeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ComponentEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderEventEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DiagnosticEntityTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
