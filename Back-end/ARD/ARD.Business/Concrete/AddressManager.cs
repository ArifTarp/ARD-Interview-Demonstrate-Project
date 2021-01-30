using ARD.Business.Abstract;
using ARD.DataAccess.Abstract;
using ARD.Entity.Concrete;
using Common.Utilities.Results;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Net;
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

        public async Task<IDataResult<ICollection<Address>>> GetAllWithProvinceAndDistrictAndStudent()
        {
            var addresses = await _addressDal.GetAllWithProvinceAndDistrictAndStudent();

            if (addresses == null)
                return new ErrorDataResult<ICollection<Address>>(new List<Address>(), HttpStatusCode.NotFound);

            return new SuccessfulDataResult<ICollection<Address>>(addresses, HttpStatusCode.OK);
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

        public async Task<Address> GetAddressByStudentId(int studentId)
        {
            return await _addressDal.GetAsync(a => a.StudentId == studentId);
        }
    }
}
