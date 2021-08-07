using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SolarSystem.Data.Models;

namespace SolarSystem.Data
{
    public class SolarSystemContext : IdentityDbContext<AppUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=SolarSystem;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Satellite>().HasMany(I => I.PlanetSatellites).WithOne(I => I.Satellite).HasForeignKey(I => I.SatelliteId);
            modelBuilder.Entity<Planet>().HasMany(I => I.PlanetSatellites).WithOne(I => I.Planet).HasForeignKey(I => I.PlanetId);
            modelBuilder.Entity<RecentNews>().HasKey(I => I.NewsId);

            modelBuilder.Entity<PlanetSatellite>().HasIndex(I => new
            {
                I.PlanetId,
                I.SatelliteId
            }).IsUnique();
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<PlanetSatellite> PlanetSatellites { get; set; }
        public DbSet<Satellite> Satellites { get; set; }
        public DbSet<Planet> Planets { get; set; }
        public DbSet<RecentNews> RecentNews { get; set; }
    }
}
