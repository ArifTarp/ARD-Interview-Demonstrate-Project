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
    [Route("api/provinces")]
    [Produces("application/json")]
    [ApiController]
    public class ProvincesController : Controller
    {
        private readonly IProvinceService _provinceService;
        private readonly IMapper _mapper;

        public ProvincesController(IProvinceService provinceService, IMapper mapper)
        {
            _provinceService = provinceService;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var provinces = await _provinceService.GetAllAsync();

            return Ok(provinces);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var provinces = await _provinceService.GetProvinceByIdAsync(id);
            if (provinces == null)
                return BadRequest("Uncorrected id.");

            return Ok(provinces);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _provinceService.DeleteProvinceAsync(id);
            return Ok();
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] ProvinceAddDto provinceAddDto)
        {
            if (provinceAddDto == null)
                return BadRequest();

            var newProvince = _mapper.Map<Province>(provinceAddDto);
            await _provinceService.AddProvinceAsync(newProvince);

            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(ProvinceUpdateDto provinceUpdateDto)
        {
            if (provinceUpdateDto == null)
                return BadRequest();

            var newProvince = _mapper.Map<Province>(provinceUpdateDto);
            await _provinceService.UpdateProvinceAsync(newProvince);
            return Ok();
        }
    }
}
