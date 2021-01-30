using ARD.Entity.Concrete;
using Core.Utilities.Results;
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

        Task<Address> AddAddressAsync(Address address);

        Task UpdateAddressAsync(Address address);

        Task<IDataResult<ICollection<Address>>> GetAllWithProvinceAndDistrictAndStudent();

        Task<Address> GetAddressByStudentId(int studentId);

    }
}
