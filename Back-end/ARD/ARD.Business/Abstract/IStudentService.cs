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
        Task<IDataResult<ICollection<Student>>> GetAllAsync();

        Task<IDataResult<Student>> GetStudentByIdAsync(int id);

        Task<IResult> DeleteStudentWithAddressAsync(int id);

        Task<IDataResult<ICollection<Student>>> GetStudentsWithAddressAsync();

        Task<IDataResult<Student>> GetStudentWithAddressByIdAsync(int studentId);

        Task<IDataResult<StudentUpdateDto>> UpdateStudentWithAddressAsync(StudentUpdateDto studentUpdateDto);

        Task<IDataResult<StudentAddDto>> AddStudentWithAddressAsync(StudentAddDto studentAddDto);

    }
}
