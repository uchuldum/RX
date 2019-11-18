using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Day1.BLL.DTObjects;
using Day1.DAL.Entities;

namespace Day1.WEB.Mapping
{
    public class BrandMapping : Profile
    {
        public BrandMapping()
        {
            CreateMap<Brand, BrandDTO>().ReverseMap();
        }
    }
}
