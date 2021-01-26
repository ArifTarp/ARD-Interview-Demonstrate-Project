using ARD.Core.DataAccess.EntityFrameworkCore;
using ARD.DataAccess.Abstract;
using ARD.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ARD.DataAccess.Concrete.EntityFrameworkCore
{
    public class EfStudentDal : EfEntityRepositoryBase<Student,ARDDataContext>,IStudentDal
    {
    }
}
