using learnAPI.Models.Domain;

namespace learnAPI.Repositories
{
    public interface IRegionRepository
    {
        IEnumerable<Region> GetAll();
    }
}
