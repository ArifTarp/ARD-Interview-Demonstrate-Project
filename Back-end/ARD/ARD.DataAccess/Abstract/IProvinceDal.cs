using ARD.Core.DataAccess;
using ARD.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ARD.DataAccess.Abstract
{
    public interface IProvinceDal : IEntityRepository<Province>
    {
        Task<List<Province>> GetListWithDistrictsAsync(Expression<Func<Province, bool>> filter = null);
        Task<Province> GetWithDistrictsAsync(Expression<Func<Province, bool>> filter);

    }
}
