using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TribalWarsHubBackEnd.Models;

namespace TribalWarsHubBackEnd.Data.Mappers
{
    public class CustomerFavoriteConfiguration : IEntityTypeConfiguration<CustomerFavorite>
    {
        public void Configure(EntityTypeBuilder<CustomerFavorite> builder)
        {
            builder.ToTable("CustomersFavorites");
            builder.HasKey(f => new { f.CustomerId, f.CommentId });
            builder.HasOne(f => f.Customer).WithMany(u => u.Favorites).HasForeignKey(f => f.CustomerId);
            builder.HasOne(f => f.Comment).WithMany().HasForeignKey(f => f.CommentId);
        }
    }
}
