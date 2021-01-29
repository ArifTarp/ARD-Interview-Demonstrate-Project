using ARD.Business.Abstract;
using ARD.DataAccess.Abstract;
using ARD.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ARD.Business.Concrete
{
    public class AddressManager : IAddressService
    {
        private readonly IAddressDal _addressDal;

        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }

        public async Task<ICollection<Address>> GetAllAsync()
        {
            return await _addressDal.GetListAsync();
        }

        public async Task<ICollection<Address>> GetAllWithProvinceAndDistrictAndStudents()
        {
            return await _addressDal.GetAllWithProvinceAndDistrictAndStudents();
        }


        public async Task<Address> GetAddressByIdAsync(int id)
        {
            return await _addressDal.GetAsync(a => a.Id == id);
        }

        public async Task<Address> AddAddressAsync(Address address)
        {
            return await _addressDal.AddAsync(address);
        }

        public async Task DeleteAddressAsync(int id)
        {
            await _addressDal.DeleteAsync(new Address { Id = id });
        }

        public async Task UpdateAddressAsync(Address address)
        {
            await _addressDal.UpdateAsync(address);
        }

        public async Task<Address> GetAddressByProvinceIdAndDistrictIdAndStudentId(int provinceId, int districtId, int studentId)
        {
            return await _addressDal.GetAsync(a => a.ProvinceId == provinceId && a.DistrictId == districtId && a.StudentId == studentId);
        }
    }
}
