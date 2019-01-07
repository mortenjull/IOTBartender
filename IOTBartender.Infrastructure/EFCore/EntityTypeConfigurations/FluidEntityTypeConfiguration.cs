using IOTBartender.Domain.Entititeis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IOTBartender.Infrastructure.EFCore.EntityTypeConfigurations
{
    public class FluidEntityTypeConfiguration
        : IEntityTypeConfiguration<Fluid>
    {
        public void Configure(EntityTypeBuilder<Fluid> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
        }
    }
}
