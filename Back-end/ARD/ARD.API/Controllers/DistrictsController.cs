using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARD.Entity.DTOs;
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

        public DistrictsController(IDistrictService districtService)
        {
            _districtService = districtService;
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
    }
}
