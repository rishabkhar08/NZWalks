using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Data
{
    public class NZWalksDbContext: DbContext
    {
        public NZWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
  
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Difficulties
            // Easy, Medium, Hard

            var difficulties = new List<Difficulty>
            {
                new Difficulty()
                {
                    Id = Guid.NewGuid(),
                    Name = "Easy"
                },
                new Difficulty() 
                {
                    Id = Guid.NewGuid(),
                    Name = "Medium"
                },
                new Difficulty() 
                {
                    Id = Guid.NewGuid(),
                    Name = "Hard"
                }
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            // Seed data for Regions

            var regions = new List<Region>
            {
                new Region()
                {
                    Id = Guid.NewGuid(),
                    Name = "New Delhi",
                    Code = "DEL",
                    RegionImageUrl = "delhi.jpg"
                },
                new Region()
                {
                    Id = Guid.NewGuid(),
                    Name = "Mumbai",
                    Code = "BOM",
                    RegionImageUrl = "mumbai.jpg"
                },
                new Region()
                {
                    Id = Guid.NewGuid(),
                    Name = "Banglore",
                    Code = "BNG",
                    RegionImageUrl = "banglore.jpg"
                },
                new Region()
                {
                    Id = Guid.NewGuid(),
                    Name = "Pune",
                    Code = "PUN",
                    RegionImageUrl = "pune.jpg"
                }
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
