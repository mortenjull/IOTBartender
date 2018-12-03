using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOTBartenderDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IOTBartender.Infrastructure.EntityTypeCinfiguration
{
    public class EntityTypeConfigurationGlass : IEntityTypeConfiguration<Glass>
    {
        public void Configure(EntityTypeBuilder<Glass> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Recipe).WithMany(x => x.Glasses);
        }
    }
}
