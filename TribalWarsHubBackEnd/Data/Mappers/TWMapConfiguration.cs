using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TribalWarsHubBackEnd.Models;

namespace TribalWarsHubBackEnd.Data.Mappers
{
    public class TWMapConfiguration : IEntityTypeConfiguration<TWMap>
    {
        public void Configure(EntityTypeBuilder<TWMap> builder)
        {
            builder.ToTable("TWMaps");
            builder.HasKey(t => t.Id);
            builder.Property(r => r.Name).IsRequired().HasMaxLength(50);
        }
    }
}
