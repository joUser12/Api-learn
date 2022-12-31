using AutoMapper;
using learnAPI.Models.Domain;
using learnAPI.Models.DTO;
using learnAPI.Repositories;
using Microsoft.AspNetCore.Authorization.Infrastructure;
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

        [HttpGet("Get Region")]
        public async Task<ActionResult> GetAllRegions()
        {

          var regions= await  regionRepository.GetAllAsync();

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
          var regionsDTO =  mapper.Map<List<Models.DTO.RegionDTO>>(regions);

            return Ok(regionsDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegion")]
        public async Task<IActionResult>GetRegion(Guid id)
        {
            var regions = await regionRepository.Get(id);
            if(regions == null)
            {
                return NotFound();  
            }
            var regionDTO =mapper.Map<Models.DTO.RegionDTO>(regions);
            return Ok(regionDTO);

        }
        [HttpPost ("AddRegion")]

        public async Task<IActionResult> AddRegionAsync(Models.DTO.AddRegionRequest addRegionRequest)
        {
            //Request (DTO) to Domain model
            var region = new Models.Domain.Region()
            {
                Code = addRegionRequest.Code,
                Area = addRegionRequest.Area,
                Lat = addRegionRequest.Lat,
                Long = addRegionRequest.Long,
                Name = addRegionRequest.Name,
                Population = addRegionRequest.Population,
            };
            //Pass details to repository
           region=  await regionRepository.addAsync(region);

            //Convert back to Dto

            var regionDTO = new Models.DTO.RegionDTO
            {
                Id= region.Id,
                Code = region.Code,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Name = region.Name,
                Population = region.Population,
            };
            return CreatedAtAction(nameof(GetRegion), new { id = regionDTO.Id }, regionDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegionAsync (Guid id)
        {

            //get Region from Database

            var region = await regionRepository.deleteAsync(id);


            //if null Not found
            if(region == null)
            {
                return NotFound();  
            }

            //Convert response back to Dto
            var regionDTO = new Models.DTO.RegionDTO
            {
                Id = region.Id,
                Code = region.Code,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Name = region.Name,
                Population = region.Population,
            };

            //return Ok response
            return Ok(regionDTO);

        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegion(Guid id,Models.DTO.UpdateRegion updateRegion)
        {

            //Convert DTO to DOmain model
            var region = new Models.Domain.Region()
            {
                Code = updateRegion.Code,
                Area = updateRegion.Area,
                Lat = updateRegion.Lat,
                Long = updateRegion.Long,
                Name = updateRegion.Name,
                Population = updateRegion.Population,
            };

            //updateRegion Region using repository

            region = await  regionRepository.updateAsync(id, region);

            if(region == null)
            {
                return NotFound();
            }


            //Convert Domain back to Dto
            var regionDTO = new Models.DTO.RegionDTO
            {
                Id = region.Id,
                Code = region.Code,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Name = region.Name,
                Population = region.Population,
            };

            //return Ok response
            return Ok(regionDTO);

    

        }


    }
}
