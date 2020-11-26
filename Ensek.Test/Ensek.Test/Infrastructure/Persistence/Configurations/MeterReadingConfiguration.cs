using Ensek.Test.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ensek.Test.Infrastructure.Persistence.Configurations
{
    internal class MeterReadingConfiguration : IEntityTypeConfiguration<MeterReading>
    {
        public void Configure(EntityTypeBuilder<MeterReading> builder)
        {
            builder.HasKey(m => m.Id);
            builder.HasOne(m => m.Account);
        }
    }
}
