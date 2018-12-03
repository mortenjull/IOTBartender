using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using IOTBartenderDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IOTBartender.Infrastructure.EntityTypeCinfiguration
{
    public class EntityTypeConfigurationComponent : IEntityTypeConfiguration<Component>
    {
        public void Configure(EntityTypeBuilder<Component> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
