using ARD.Business.Abstract;
using ARD.DataAccess.Abstract;
using ARD.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ARD.Business.Concrete
{
    public class DistrictManager : IDistrictService
    {
        private readonly IDistrictDal _districtDal;

        public DistrictManager(IDistrictDal districtDal)
        {
            _districtDal = districtDal;
        }

        public async Task<ICollection<District>> GetAllAsync()
        {
            return await _districtDal.GetListAsync();
        }

        public async Task<District> GetDistrictByIdAsync(int id)
        {
            return await _districtDal.GetAsync(s => s.Id == id);
        }

        public async Task AddDistrictAsync(District district)
        {
            await _districtDal.AddAsync(district);
        }

        public async Task DeleteDistrictAsync(int id)
        {
            await _districtDal.DeleteAsync(new District { Id = id });
        }

        public async Task UpdateDistrictAsync(District district)
        {
            await _districtDal.UpdateAsync(district);
        }
    }
}
