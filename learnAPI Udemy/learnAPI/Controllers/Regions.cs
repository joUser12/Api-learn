using AutoMapper;
using learnAPI.Models.Domain;
using learnAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace learnAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Regions : Controller

    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public Regions(IRegionRepository regionRepository,IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllRegions()
        {

          var regions=  regionRepository.GetAll();

            //return DTO regions

            //var regionsDTO = new List<Models.DTO.Region>();
            //regions.ToList().ForEach(region =>
            //{
            //    var regionDTO = new Models.DTO.Region()
            //    {
            //        Id= region.Id,
            //        Name = region.Name,
            //        Code= region.Code,
            //        Area= region.Area,
            //        Lat= region.Lat,
            //        Long= region.Long,
            //        Population= region.Population,
            //    };

            //    regionsDTO.Add(regionDTO);


            //});
          var regionsDTO =  mapper.Map<List<Models.DTO.Region>>(regions);

            return Ok(regionsDTO);
        }
       
    }
}
