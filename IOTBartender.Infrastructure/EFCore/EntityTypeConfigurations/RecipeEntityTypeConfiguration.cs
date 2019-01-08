using IOTBartender.Domain.Entititeis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IOTBartender.Infrastructure.EFCore.EntityTypeConfigurations
{
    public class RecipeEntityTypeConfiguration
        : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Components).WithOne(x => x.Recipe);
            builder.HasMany(x => x.Orders).WithOne(x => x.Recipe);
        }
    }
}
