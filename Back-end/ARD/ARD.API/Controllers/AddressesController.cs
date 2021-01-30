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
        private readonly IMapper _mapper;
        private readonly IProvinceService _provinceService;
        private readonly IDistrictService _districtService;

        public AddressesController(
            IAddressService addressService,
            IMapper mapper,
            IProvinceService provinceService,
            IDistrictService districtService)
        {
            _addressService = addressService;
            _mapper = mapper;
            _provinceService = provinceService;
            _districtService = districtService;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var addresses = await _addressService.GetAllAsync();

            return Ok(addresses);
        }

        [HttpGet("getAllWithProvinceAndDistrictAndStudent")]
        public async Task<IActionResult> GetAllWithProvinceAndDistrictAndStudent()
        {
            var addresses = await _addressService.GetAllWithProvinceAndDistrictAndStudent();

            return Ok(addresses);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var address = await _addressService.GetAddressByIdAsync(id);
            if (address == null)
                return BadRequest("Uncorrected id.");

            return Ok(address);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _addressService.DeleteAddressAsync(id);
            return Ok();
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AddressAddDto addressAddDto)
        {
            if (addressAddDto == null)
                return BadRequest();

            var existingProvince = await _provinceService.GetByNameAsync(addressAddDto.Province);
            var existingDistrict = await _districtService.GetByNameAsync(addressAddDto.District);

            if (existingProvince == null || existingDistrict == null)
                return BadRequest();

            var modelforMap = new AddressAddForMapDto
            {
                Province = existingProvince,
                District = existingDistrict,
                AddressAddDto = addressAddDto
            };
            var newAddress = _mapper.Map<Address>(modelforMap);
            await _addressService.AddAddressAsync(newAddress);

            return Ok(addressAddDto);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(AddressUpdateDto addressUpdateDto)
        {
            if (addressUpdateDto == null)
                return BadRequest();

            var existingProvince = await _provinceService.GetByNameAsync(addressUpdateDto.ProvinceName);
            var existingDistrict = await _districtService.GetByNameAsync(addressUpdateDto.DistrictName);

            if (existingProvince == null || existingDistrict == null)
                return BadRequest();

            var modelforMap = new AddressUpdateForMapDto
            {
                Province = existingProvince,
                District = existingDistrict,
                AddressUpdateDto = addressUpdateDto
            };
            var newAddress = _mapper.Map<Address>(modelforMap);
            await _addressService.UpdateAddressAsync(newAddress);

            return Ok(addressUpdateDto);
        }

    }
}
