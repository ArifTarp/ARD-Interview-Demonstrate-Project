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
        public async Task<List<Student>> GetStudentsWithAddresses(Expression<Func<Student, bool>> filter = null)
        {
            using (var context = new ARDDataContext())
            {
                if (filter == null)
                    return await context.Set<Student>().Include(s => s.Address).Include(a => a.Address.District).Include(a => a.Address.Province).ToListAsync();
                return await context.Set<Student>().Include(s => s.Address).Include(a => a.Address.District).Include(a => a.Address.Province).Where(filter).ToListAsync();
            }
        }

        public async Task<Student> GetStudentWithAddress(Expression<Func<Student, bool>> filter = null)
        {
            using (var context = new ARDDataContext())
            {
                return await context.Set<Student>().Include(s => s.Address).Include(a => a.Address.District).Include(a => a.Address.Province).Where(filter).SingleOrDefaultAsync();
            }
        }
    }
}
