using IOTBartender.Domain.Entititeis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IOTBartender.Infrastructure.EFCore.EntityTypeConfigurations
{
    public class ComponentEntityTypeConfiguration
        : IEntityTypeConfiguration<Component>
    {
        public void Configure(EntityTypeBuilder<Component> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Fluid).WithMany(x => x.Components);
        }
    }
}
