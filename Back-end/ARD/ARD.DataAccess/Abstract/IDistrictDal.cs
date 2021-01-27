using ARD.Core.DataAccess;
using ARD.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ARD.DataAccess.Abstract
{
    public interface IDistrictDal : IEntityRepository<District>
    {
    }
}
