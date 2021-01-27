using ARD.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ARD.Business.Abstract
{
    public interface IProvinceService
    {
        Task<ICollection<Province>> GetAllAsync();

        Task<Province> GetProvinceByIdAsync(int id);

        Task AddProvinceAsync(Province province);

        Task DeleteProvinceAsync(int id);

        Task UpdateProvinceAsync(Province province);

        Task<ICollection<Province>> GetAllWithDistrictsAsync();
        Task<Province> GetByNameAsync(string name);
    }
}
