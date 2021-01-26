using ARD.API.DTOs;
using ARD.Entity.Concrete;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARD.API.Mapper.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<StudentAddDto, Student>().ReverseMap();
            CreateMap<StudentUpdateDto, Student>().ReverseMap();

            CreateMap<AddressAddDto, Address>().ReverseMap();
            CreateMap<AddressUpdateDto, Address>().ReverseMap();
        }
    }
}
