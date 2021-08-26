using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TribalWarsHubBackEnd.Models;

namespace TribalWarsHubBackEnd.Data.Mappers
{
    public class PlayerODConfiguration : IEntityTypeConfiguration<PlayerOD>
    {
        public void Configure(EntityTypeBuilder<PlayerOD> builder)
        {
            builder.ToTable("PlayerODs");
            builder.HasKey(t => t.ID);
            builder.Property(t => t.ID).ValueGeneratedOnAdd();
        }
    }
}
