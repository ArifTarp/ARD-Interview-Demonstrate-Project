﻿using ARD.Core.DataAccess;
using ARD.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ARD.DataAccess.Abstract
{
    public interface IStudentDal : IEntityRepository<Student>
    {
        Task<List<Student>> GetStudentsWithAddresses(Expression<Func<Student, bool>> filter = null);
        Task<Student> GetStudentWithAddress(Expression<Func<Student, bool>> filter = null);
    }
}
