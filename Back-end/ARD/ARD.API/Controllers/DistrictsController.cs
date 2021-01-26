using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARD.API.DTOs;
using ARD.Business.Abstract;
using ARD.Entity.Concrete;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ARD.API.Controllers
{
    [Route("api/districts")]
    [Produces("application/json")]
    [ApiController]
    public class DistrictsController : Controller
    {
        private readonly IDistrictService _districtService;
        private readonly IMapper _mapper;

        public DistrictsController(IDistrictService districtService, IMapper mapper)
        {
            _districtService = districtService;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var districts = await _districtService.GetAllAsync();

            return Ok(districts);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var district = await _districtService.GetDistrictByIdAsync(id);
            if (district == null)
                return BadRequest("Uncorrected id.");

            return Ok(district);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _districtService.DeleteDistrictAsync(id);
            return Ok();
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] DistrictAddDto districtAddDto)
        {
            if (districtAddDto == null)
                return BadRequest();

            var newDistrict = _mapper.Map<District>(districtAddDto);
            await _districtService.AddDistrictAsync(newDistrict);

            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(DistrictUpdateDto districtUpdateDto)
        {
            if (districtUpdateDto == null)
                return BadRequest();

            var newDistrict = _mapper.Map<District>(districtUpdateDto);
            await _districtService.UpdateDistrictAsync(newDistrict);
            return Ok();
        }
    }
}
