using learnAPI.Data;
using learnAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace learnAPI.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NzWalksDbContext nzWalksDbContext;

        public RegionRepository(NzWalksDbContext nzWalksDbContext)
        {
            this.nzWalksDbContext = nzWalksDbContext;
        }

        public  async Task<Region> addAsync(Region region)
        {
            region.Id= Guid.NewGuid();
           await nzWalksDbContext.Regions.AddAsync(region);
           await  nzWalksDbContext.SaveChangesAsync();
            return region;
           
        }



        //public  IEnumerable<Region> GetAll()
        //{

        //  return  nzWalksDbContext.Regions.ToList();
        //}
        public async Task<Region> Get(Guid id)
        {
          return await nzWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

         public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return  await nzWalksDbContext.Regions.ToListAsync();
        }

        public async Task<Region> updateAsync(Guid id, Region region)
        {
            var existRegion = await nzWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if(existRegion == null)
            {
                return null;
            }

            existRegion.Area = region.Area;
            existRegion.Code= region.Code;  
            existRegion.Name= region.Name;  
            existRegion.Lat= region.Lat;
            existRegion.Long= region.Long;
            existRegion.Population= region.Population;

            await nzWalksDbContext.SaveChangesAsync();
            return existRegion;


        }

         async Task<Region> IRegionRepository.deleteAsync(Guid id)
        {
           var region   = await  nzWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if(region == null)
            {
                return null;

            }
            nzWalksDbContext.Regions.Remove(region);
            await nzWalksDbContext.SaveChangesAsync();
            return region;

        }
    }
}
