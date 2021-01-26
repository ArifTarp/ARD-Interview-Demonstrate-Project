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
    public class AddressesController : Controller
    {
        
            private readonly IAddressService _addressService;
            private readonly IMapper _mapper;

            public AddressesController(IAddressService addressService, IMapper mapper)
            {
            _addressService = addressService;
                _mapper = mapper;
            }

            [HttpGet()]
            public async Task<IActionResult> Get()
            {
                var addresses = await _addressService.GetAllAsync();

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

            [HttpDelete("delete")]
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

                var newAddress = _mapper.Map<Address>(addressAddDto);
                await _addressService.AddAddressAsync(newAddress);

                return Ok();
            }

            [HttpPut("update")]
            public async Task<IActionResult> Update(AddressUpdateDto addressUpdateDto)
            {
                if (addressUpdateDto == null)
                    return BadRequest();

                var newAddress = _mapper.Map<Address>(addressUpdateDto);
                await _addressService.UpdateAddressAsync(newAddress);
                return Ok();
            }
        
    }
}
