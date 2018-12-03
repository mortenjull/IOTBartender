using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOTBartenderDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IOTBartender.Infrastructure.EntityTypeCinfiguration
{
    public class EntitypeTypeConfigurationRecipe : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Components).WithOne(x => x.Recipe);
        }
    }
}
