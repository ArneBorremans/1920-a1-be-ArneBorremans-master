using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TribalWarsHubBackEnd.Models;

namespace TribalWarsHubBackEnd.Data.Mappers
{
    public class TribeODConfiguration : IEntityTypeConfiguration<TribeOD>
    {
        public void Configure(EntityTypeBuilder<TribeOD> builder)
        {
            builder.ToTable("TribeODs");
            builder.HasKey(t => t.ID);
            builder.Property(t => t.ID).ValueGeneratedOnAdd();
        }
    }
}
