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
    public class EfAddressDal : EfEntityRepositoryBase<Address, ARDDataContext>, IAddressDal
    {
        public async Task<ICollection<Address>> GetAllWithProvinceAndDistrictAndStudent(Expression<Func<Address, bool>> filter = null)
        {
            using (var context = new ARDDataContext())
            {
                if (filter == null)
                    return await context.Set<Address>().Include(a => a.Province).Include(a => a.District).Include(a => a.Student).ToListAsync();
                return await context.Set<Address>().Include(a => a.Province).Include(a => a.District).Include(a => a.Student).Where(filter).ToListAsync();
            }
        }

    }
}
