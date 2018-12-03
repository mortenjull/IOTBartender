using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOTBartender.Infrastructure.EntityTypeCinfiguration;
using IOTBartenderDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IOTBartender.Infrastructure
{
    public class ApplicationDbContext
    : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new EntityTypeConfigurationGlass());
            modelBuilder.ApplyConfiguration(new EntitypeTypeConfigurationRecipe());
            modelBuilder.ApplyConfiguration(new EntityTypeConfigurationComponent());
            modelBuilder.ApplyConfiguration(new EntityTypeConfigurationOrder());
        }

        public DbSet<Glass> Glasses { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Component> Components { get; set; }
        
        public DbSet<Order> Orders { get; set; }
    }
}
