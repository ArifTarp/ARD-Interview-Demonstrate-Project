using ARD.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ARD.Business.Abstract
{
    public interface IAddressService
    {
        Task<ICollection<Address>> GetAllAsync();

        Task<Address> GetAddressByIdAsync(int id);

        Task AddAddressAsync(Address address);

        Task DeleteAddressAsync(int id);

        Task UpdateAddressAsync(Address address);

        Task<Address> GetAddressByProvinceIdAndDistrictId(int provinceId, int districtId);
    }
}
