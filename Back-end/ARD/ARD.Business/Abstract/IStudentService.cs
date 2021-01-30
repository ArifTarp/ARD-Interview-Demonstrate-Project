using ARD.Entity.Concrete;
using ARD.Entity.DTOs;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ARD.Business.Abstract
{
    public interface IStudentService
    {
        Task<ICollection<Student>> GetAllAsync();

        Task<Student> GetStudentByIdAsync(int id);

        Task<Student> AddStudentAsync(Student student);

        Task<IResult> DeleteStudentAsync(int id);

        Task UpdateStudentAsync(Student student);

        Task<ICollection<Student>> GetStudentsWithAddressAsync();

        Task<Student> GetStudentWithAddressByIdAsync(int studentId);

        Task<IDataResult<StudentUpdateDto>> UpdateStudentWithAddressAsync(StudentUpdateDto studentUpdateDto);

        Task<IDataResult<StudentAddDto>> AddStudentWithAddressAsync(StudentAddDto studentAddDto);

    }
}
