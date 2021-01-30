using ARD.Entity.DTOs;
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

            CreateMap<AddressAddForMapDto, Address>()
            .ForMember(dest => dest.ProvinceId, opt =>
            {
                opt.MapFrom(src => src.Province.Id);
            })
            .ForMember(dest => dest.DistrictId, opt =>
            {
                opt.MapFrom(src => src.District.Id);
            })
            .ForMember(dest => dest.AddressDetail, opt =>
            {
                opt.MapFrom(src => src.AddressAddDto.AddressDetail);
            });

            CreateMap<AddressUpdateForMapDto, Address>()
            .ForMember(dest => dest.Id, opt =>
            {
                opt.MapFrom(src => src.AddressUpdateDto.Id);
            })
            .ForMember(dest => dest.ProvinceId, opt =>
            {
                opt.MapFrom(src => src.Province.Id);
            })
            .ForMember(dest => dest.DistrictId, opt =>
            {
                opt.MapFrom(src => src.District.Id);
            })
            .ForMember(dest => dest.AddressDetail, opt =>
            {
                opt.MapFrom(src => src.AddressUpdateDto.AddressDetail);
            });
        }
    }
}
