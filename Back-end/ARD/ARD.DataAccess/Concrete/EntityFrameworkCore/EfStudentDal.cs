using ARD.Core.DataAccess.EntityFrameworkCore;
using ARD.DataAccess.Abstract;
using ARD.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ARD.DataAccess.Concrete.EntityFrameworkCore
{
    public class EfStudentDal : EfEntityRepositoryBase<Student,ARDDataContext>,IStudentDal
    {
        public async Task<List<Student>> GetStudentsWithAddress(Expression<Func<Student, bool>> filter = null)
        {
            using (var context = new ARDDataContext())
            {
                if (filter == null)
                    return await context.Set<Student>()
                        .Include(s => s.Address)
                        .Include(s => s.Address.Province)
                        .Include(s => s.Address.District)
                        .Select(s => new Student { 
                            Id = s.Id, 
                            FirstName = s.FirstName,
                            LastName = s.LastName,
                            SchoolIdentity = s.SchoolIdentity,
                            Address = new Address { 
                                Id = s.Address.Id,
                                AddressDetail = s.Address.AddressDetail, 
                                ProvinceId = s.Address.ProvinceId,
                                DistrictId = s.Address.District.Id,
                                StudentId = s.Address.StudentId,
                                Province = new Province { Id = s.Address.Province.Id, Name = s.Address.Province.Name},
                                District = new District { Id = s.Address.District.Id, Name = s.Address.District.Name}
                            }
                        }).ToListAsync();

                return await context.Set<Student>()
                        .Include(s => s.Address)
                        .Include(s => s.Address.Province)
                        .Include(s => s.Address.District)
                        .Select(s => new Student
                        {
                            Id = s.Id,
                            FirstName = s.FirstName,
                            LastName = s.LastName,
                            SchoolIdentity = s.SchoolIdentity,
                            Address = new Address
                            {
                                Id = s.Address.Id,
                                AddressDetail = s.Address.AddressDetail,
                                ProvinceId = s.Address.ProvinceId,
                                DistrictId = s.Address.District.Id,
                                StudentId = s.Address.StudentId,
                                Province = new Province { Id = s.Address.Province.Id, Name = s.Address.Province.Name },
                                District = new District { Id = s.Address.District.Id, Name = s.Address.District.Name }
                            }
                        }).Where(filter).ToListAsync();
            }
        }

        public async Task<Student> GetStudentWithAddressByIdAsync(Expression<Func<Student, bool>> filter)
        {
            using (var context = new ARDDataContext())
            {
                return await context.Set<Student>().Include(s => s.Address).Include(a => a.Address.District).Include(a => a.Address.Province).Where(filter).SingleOrDefaultAsync();
            }
        }
    }
}
