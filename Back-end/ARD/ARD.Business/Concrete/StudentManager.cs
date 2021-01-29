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

        public async Task<ICollection<Student>> GetStudentsWithAddressAsync()
        {
            return await _studentDal.GetStudentsWithAddress();
        }

        public async Task<Student> GetStudentWithAddressByIdAsync(int studentId)
        {
            return await _studentDal.GetStudentWithAddressByIdAsync(s => s.Id == studentId);
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _studentDal.GetAsync(s => s.Id == id);
        }

        public async Task<Student> AddStudentAsync(Student student)
        {
            return await _studentDal.AddAsync(student);
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
