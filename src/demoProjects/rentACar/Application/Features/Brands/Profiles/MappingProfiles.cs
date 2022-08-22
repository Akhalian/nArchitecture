using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Brands.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Brand, CreatedBrandDto>().ReverseMap();
            CreateMap<Brand, CreateBrandCommand>().ReverseMap();
        }
    }
}
