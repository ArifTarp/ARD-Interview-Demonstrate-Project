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

        public async Task<Address> GetAddressByIdAsync(int id)
        {
            return await _addressDal.GetAsync(a => a.Id == id);
        }

        public async Task AddAddressAsync(Address address)
        {
            await _addressDal.AddAsync(address);
        }

        public async Task DeleteAddressAsync(int id)
        {
            await _addressDal.DeleteAsync(new Address { Id = id });
        }

        public async Task UpdateAddressAsync(Address address)
        {
            await _addressDal.UpdateAsync(address);
        }
    }
}
