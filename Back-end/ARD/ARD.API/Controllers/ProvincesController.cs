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

        public ProvincesController(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var provinces = await _provinceService.GetAllAsync();

            return Ok(provinces);
        }

        [HttpGet("getAllWithDistricts")]
        public async Task<IActionResult> GetAllWithDistricts()
        {
            var provinces = await _provinceService.GetAllWithDistrictsAsync();

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
    }
}
