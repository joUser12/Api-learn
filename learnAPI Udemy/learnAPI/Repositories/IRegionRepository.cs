using learnAPI.Models.Domain;

namespace learnAPI.Repositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllAsync();
        
        Task<Region> Get(Guid id);

         Task <Region> addAsync(Region region);

         Task <Region>deleteAsync(Guid id);

        Task<Region> updateAsync(Guid id,Region region);
    }
}
