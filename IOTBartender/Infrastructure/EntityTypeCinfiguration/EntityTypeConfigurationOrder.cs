using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOTBartenderDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IOTBartender.Infrastructure.EntityTypeCinfiguration
{
    public class EntityTypeConfigurationOrder : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Glass).WithMany(x => x.Orders);
            builder.HasOne(x => x.Recipe).WithMany(x => x.Orders);
        }
    }
}
