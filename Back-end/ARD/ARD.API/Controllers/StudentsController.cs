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
    [Route("api/students")]
    [Produces("application/json")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IAddressService _addressService;

        public StudentsController(IStudentService studentService, IMapper mapper, IAddressService addressService)
        {
            _studentService = studentService;
            _mapper = mapper;
            _addressService = addressService;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var students = await _studentService.GetAllAsync();

            return Ok(students);
        }

        [HttpGet("getAllWithAddresses")]
        public async Task<IActionResult> GetAllWithAddresses()
        {
            var students = await _studentService.GetStudentsWithAddressesAsync();

            return Ok(students);
        }

        [HttpGet("getStudentWithAddressesById/{id}")]
        public async Task<IActionResult> GetStudentWithAddressesById(int id)
        {
            var student = await _studentService.GetStudentWithAddressByIdAsync(id);

            return Ok(student);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
                return BadRequest("Uncorrected id.");

            return Ok(student);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _studentService.DeleteStudentAsync(id);
            return Ok();
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] StudentAddDto studentAddDto)
        {
            if (studentAddDto == null)
                return BadRequest();

            var existingAddress = await _addressService.GetAddressByProvinceIdAndDistrictId(studentAddDto.ProvinceId, studentAddDto.DistrictId);

            if (existingAddress == null)
                return BadRequest();

            var newStudent = _mapper.Map<Student>(studentAddDto);
            newStudent.AddressId = existingAddress.Id;
            await _studentService.AddStudentAsync(newStudent);

            return Ok(studentAddDto);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(StudentUpdateDto studentUpdateDto)
        {
            if (studentUpdateDto == null)
                return BadRequest();

            var newStudent = _mapper.Map<Student>(studentUpdateDto);
            await _studentService.UpdateStudentAsync(newStudent);
            return Ok();
        }
    }
}
