using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TribalWarsHubBackEnd.Models;

namespace TribalWarsHubBackEnd.Data.Mappers
{
    public class TribeConfiguration : IEntityTypeConfiguration<Tribe>
    {
        public void Configure(EntityTypeBuilder<Tribe> builder)
        {
            builder.ToTable("Tribes");
            builder.HasKey(t => t.ID);
            builder.Property(t => t.ID).ValueGeneratedOnAdd();
            builder.Property(t => t.Name).IsRequired().HasMaxLength(100);
        }
    }
}
