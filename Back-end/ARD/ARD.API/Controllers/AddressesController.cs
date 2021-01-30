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
    [Route("api/addresses")]
    [Produces("application/json")]
    [ApiController]
    public class AddressesController : Controller
    {

        private readonly IAddressService _addressService;

        public AddressesController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet("getAllWithProvinceAndDistrictAndStudent")]
        public async Task<IActionResult> GetAllWithProvinceAndDistrictAndStudent()
        {
            var result = await _addressService.GetAllWithProvinceAndDistrictAndStudent();
            return StatusCode(result.HttpStatusCode, result.Data);
        }

    }
}
