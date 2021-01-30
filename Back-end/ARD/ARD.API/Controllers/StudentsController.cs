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
    [Route("api/students")]
    [Produces("application/json")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IAddressService _addressService;
        private readonly IProvinceService _provinceService;

        public StudentsController(
            IStudentService studentService,
            IMapper mapper,
            IAddressService addressService,
            IProvinceService provinceService)
        {
            _studentService = studentService;
            _mapper = mapper;
            _addressService = addressService;
            _provinceService = provinceService;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var students = await _studentService.GetAllAsync();

            return Ok(students);
        }

        [HttpGet("getAllWithAddress")]
        public async Task<IActionResult> GetAllWithAddress()
        {
            var students = await _studentService.GetStudentsWithAddressAsync();

            return Ok(students);
        }

        [HttpGet("getStudentWithAddressById/{id}")]
        public async Task<IActionResult> GetStudentWithAddressById(int id)
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

            var existingProvinceWithDistrict = await _provinceService.GetByProvinceIdAndDistrictId(
                studentAddDto.ProvinceId,
                studentAddDto.DistrictId);

            if (existingProvinceWithDistrict == null)
                return BadRequest();

            var newStudent = _mapper.Map<Student>(studentAddDto);
            var addedStudent = await _studentService.AddStudentAsync(newStudent);

            await _addressService.AddAddressAsync(
                new Address
                {
                    ProvinceId = studentAddDto.ProvinceId,
                    DistrictId = studentAddDto.DistrictId,
                    AddressDetail = studentAddDto.AddressDetail,
                    StudentId = addedStudent.Id
                });

            return Ok(studentAddDto);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(StudentUpdateDto studentUpdateDto)
        {
            if (studentUpdateDto == null)
                return BadRequest();

            var existingAddress = await _addressService.GetAddressByStudentId(studentUpdateDto.Id);

            if (existingAddress == null)
                return BadRequest();

            var newStudent = _mapper.Map<Student>(studentUpdateDto);
            await _studentService.UpdateStudentAsync(newStudent);
            await _addressService.UpdateAddressAsync(
                new Address
                {
                    Id = existingAddress.Id,
                    ProvinceId = studentUpdateDto.ProvinceId,
                    DistrictId = studentUpdateDto.DistrictId,
                    AddressDetail = studentUpdateDto.AddressDetail,
                    StudentId = studentUpdateDto.Id
                });

            return Ok(studentUpdateDto);
        }
    }
}
