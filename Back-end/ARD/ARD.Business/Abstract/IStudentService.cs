using ARD.Entity.Concrete;
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

        Task AddStudentAsync(Student student);

        Task DeleteStudentAsync(int id);

        Task UpdateStudentAsync(Student student);

        Task<ICollection<Student>> GetStudentsWithAddressesAsync();

        Task<Student> GetStudentWithAddressByIdAsync(int studentId);

    }
}
