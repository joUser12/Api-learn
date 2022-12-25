using learnAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace learnAPI.Data
{
    public class NzWalksDbContext :DbContext
    {
        public NzWalksDbContext(DbContextOptions<NzWalksDbContext> options):base(options) { 

        }

        public DbSet<Region> Regions { get; set; }
        public DbSet<walk> walks { get; set; }

        public DbSet<WalkDifficulty> WalkDifficulty { get; set; }

    }
}
