using ARD.Business.Abstract;
using ARD.DataAccess.Abstract;
using ARD.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ARD.Business.Concrete
{
    public class StudentManager : IStudentService
    {
        private readonly IStudentDal _studentDal;

        public StudentManager(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }

        public async Task<ICollection<Student>> GetAllAsync()
        {
            return await _studentDal.GetListAsync();
        }

        public async Task<ICollection<Student>> GetStudentsWithAddressesAsync()
        {
            return await _studentDal.GetStudentsWithAddresses();
        }

        public async Task<Student> GetStudentWithAddressById(int studentId)
        {
            return await _studentDal.GetStudentWithAddressById(s => s.Id == studentId);
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _studentDal.GetAsync(s => s.Id == id);
        }

        public async Task AddStudentAsync(Student student)
        {
            await _studentDal.AddAsync(student);
        }

        public async Task DeleteStudentAsync(int id)
        {
            await _studentDal.DeleteAsync(new Student { Id = id });
        }

        public async Task UpdateStudentAsync(Student student)
        {
            await _studentDal.UpdateAsync(student);
        }
    }
}
