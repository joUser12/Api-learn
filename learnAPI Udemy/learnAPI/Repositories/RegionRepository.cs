using learnAPI.Data;
using learnAPI.Models.Domain;

namespace learnAPI.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NzWalksDbContext nzWalksDbContext;

        public RegionRepository(NzWalksDbContext nzWalksDbContext)
        {
            this.nzWalksDbContext = nzWalksDbContext;
        }

        public  IEnumerable<Region> GetAll()
        {

          return  nzWalksDbContext.Regions.ToList();
        }
    }
}
