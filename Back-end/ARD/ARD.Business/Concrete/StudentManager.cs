using ARD.Business.Abstract;
using ARD.DataAccess.Abstract;
using ARD.Entity.Concrete;
using ARD.Entity.DTOs;
using AutoMapper;
using Common.Utilities.Results;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ARD.Business.Concrete
{
    public class StudentManager : IStudentService
    {
        private readonly IStudentDal _studentDal;
        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;
        private readonly IProvinceService _provinceService;

        public StudentManager(IStudentDal studentDal, IAddressService addressService, IMapper mapper, IProvinceService provinceService)
        {
            _studentDal = studentDal;
            _addressService = addressService;
            _mapper = mapper;
            _provinceService = provinceService;
        }

        public async Task<ICollection<Student>> GetAllAsync()
        {
            return await _studentDal.GetListAsync();
        }

        public async Task<ICollection<Student>> GetStudentsWithAddressAsync()
        {
            return await _studentDal.GetStudentsWithAddress();
        }

        public async Task<Student> GetStudentWithAddressByIdAsync(int studentId)
        {
            return await _studentDal.GetStudentWithAddressByIdAsync(s => s.Id == studentId);
        }

        public async Task<IDataResult<Student>> GetStudentByIdAsync(int id)
        {
            var student = await _studentDal.GetAsync(s => s.Id == id);

            if (student == null)
                return new ErrorDataResult<Student>(new Student { Id = id},HttpStatusCode.NotFound);

            return new SuccessfulDataResult<Student>(student, HttpStatusCode.OK);
        }

        public async Task<Student> AddStudentAsync(Student student)
        {
            return await _studentDal.AddAsync(student);
        }

        public async Task<IResult> DeleteStudentAsync(int id)
        {
            var student = GetStudentByIdAsync(id);
            if (student == null)
                return new ErrorResult(HttpStatusCode.NotFound);

            await _studentDal.DeleteAsync(new Student { Id = id });

            return new SuccessfulResult(HttpStatusCode.OK);
        }

        public async Task UpdateStudentAsync(Student student)
        {
            await _studentDal.UpdateAsync(student);
        }

        public async Task<IDataResult<StudentAddDto>> AddStudentWithAddressAsync(StudentAddDto studentAddDto)
        {
            if (studentAddDto == null)
                return new ErrorDataResult<StudentAddDto>(studentAddDto, HttpStatusCode.NotAcceptable);

            var existingProvinceWithDistrict = await _provinceService.GetByProvinceIdAndDistrictId(
                studentAddDto.ProvinceId,
                studentAddDto.DistrictId);

            if (existingProvinceWithDistrict == null)
                return new ErrorDataResult<StudentAddDto>(studentAddDto, HttpStatusCode.NotFound);

            var newStudent = _mapper.Map<Student>(studentAddDto);
            var addedStudent = await AddStudentAsync(newStudent);

            await AddAddress(studentAddDto, addedStudent);

            return new SuccessfulDataResult<StudentAddDto>(studentAddDto, HttpStatusCode.OK);
        }

        private async Task AddAddress(StudentAddDto studentAddDto, Student addedStudent)
        {
            await _addressService.AddAddressAsync(
                new Address
                {
                    ProvinceId = studentAddDto.ProvinceId,
                    DistrictId = studentAddDto.DistrictId,
                    AddressDetail = studentAddDto.AddressDetail,
                    StudentId = addedStudent.Id
                });
        }

        public async Task<IDataResult<StudentUpdateDto>> UpdateStudentWithAddressAsync(StudentUpdateDto studentUpdateDto)
        {
            if (studentUpdateDto == null)
                return new ErrorDataResult<StudentUpdateDto>(studentUpdateDto, HttpStatusCode.NotAcceptable);

            var existingAddress = await _addressService.GetAddressByStudentId(studentUpdateDto.Id);

            if (existingAddress == null)
                return new ErrorDataResult<StudentUpdateDto>(studentUpdateDto, HttpStatusCode.NotFound);

            var newStudent = _mapper.Map<Student>(studentUpdateDto);

            await UpdateStudentAsync(newStudent);

            await UpdateAddress(studentUpdateDto, existingAddress);

            return new SuccessfulDataResult<StudentUpdateDto>(studentUpdateDto, HttpStatusCode.OK);
        }

        private async Task UpdateAddress(StudentUpdateDto studentUpdateDto, Address existingAddress)
        {
            await _addressService.UpdateAddressAsync(
                new Address
                {
                    Id = existingAddress.Id,
                    ProvinceId = studentUpdateDto.ProvinceId,
                    DistrictId = studentUpdateDto.DistrictId,
                    AddressDetail = studentUpdateDto.AddressDetail,
                    StudentId = studentUpdateDto.Id
                });
        }
    }
}
