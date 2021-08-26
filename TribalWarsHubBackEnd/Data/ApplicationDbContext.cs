using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TribalWarsHubBackEnd.Data.Mappers;
using TribalWarsHubBackEnd.Models;

namespace TribalWarsHubBackEnd.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<TWMap> TWMaps { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Village> Villages { get;set; }
        public DbSet<Tribe> Tribes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<PlayerOD>  PlayerODs { get; set; }
        public DbSet<TribeOD> TribeODs { get; set; }
        public DbSet<Customer> Customers { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new PlayerConfiguration());
            builder.ApplyConfiguration(new PlayerODConfiguration());
            builder.ApplyConfiguration(new TWMapConfiguration());
            builder.ApplyConfiguration(new VillageConfiguration());
            builder.ApplyConfiguration(new TribeConfiguration());
            builder.ApplyConfiguration(new TribeODConfiguration());
            builder.ApplyConfiguration(new CommentConfiguration());
            builder.ApplyConfiguration(new CustomerConfiguration());
            builder.ApplyConfiguration(new CustomerFavoriteConfiguration());
        }
    }
}
