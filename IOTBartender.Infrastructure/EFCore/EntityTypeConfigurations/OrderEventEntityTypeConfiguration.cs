using IOTBartender.Domain.Entititeis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IOTBartender.Infrastructure.EFCore.EntityTypeConfigurations
{
    public class OrderEventEntityTypeConfiguration
        : IEntityTypeConfiguration<OrderEvent>
    {
        public void Configure(EntityTypeBuilder<OrderEvent> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
