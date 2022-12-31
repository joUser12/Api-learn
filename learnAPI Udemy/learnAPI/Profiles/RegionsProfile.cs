using AutoMapper;
using learnAPI.Models.Domain;
using learnAPI.Models.DTO;

namespace learnAPI.Profiles
{
    public class RegionsProfile :Profile
    {

        public RegionsProfile()
        {
            CreateMap<Models.Domain.Region, Models.DTO.RegionDTO>()
                .ReverseMap();
        
        }
    }
}
