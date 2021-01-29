using ARD.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ARD.Business.Abstract
{
    public interface IDistrictService
    {
        Task<ICollection<District>> GetAllAsync();

        Task<District> GetDistrictByIdAsync(int id);


        Task<District> GetByNameAsync(string name);

    }
}
