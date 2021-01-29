using ARD.Business.Abstract;
using ARD.DataAccess.Abstract;
using ARD.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ARD.Business.Concrete
{
    public class ProvinceManager : IProvinceService
    {
        private readonly IProvinceDal _provinceDal;

        public ProvinceManager(IProvinceDal provinceDal)
        {
            _provinceDal = provinceDal;
        }

        public async Task<ICollection<Province>> GetAllAsync()
        {
            return await _provinceDal.GetListAsync();
        }

        public async Task<ICollection<Province>> GetAllWithDistrictsAsync()
        {
            return await _provinceDal.GetListWithDistrictsAsync();
        }

        public async Task<Province> GetByNameAsync(string name)
        {
            return await _provinceDal.GetAsync(p => p.Name == name);
        }


        public async Task<Province> GetProvinceByIdAsync(int id)
        {
            return await _provinceDal.GetAsync(s => s.Id == id);
        }

        public async Task<Province> GetByProvinceIdAndDistrictId(int provinceId, int districtId)
        {
            return await _provinceDal.GetWithDistrictsAsync(p=>p.Id==provinceId && p.Districts.Contains(new District { Id = districtId }));
        }
    }
}
