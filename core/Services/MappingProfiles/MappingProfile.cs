using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using shared;

namespace Services.MappingProfiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {

            CreateMap<Product, ProductResultDto>()
                .ForMember(d => d.BrandName, options => options.MapFrom(s => s.productBrand.name))
                .ForMember(d => d.TypeName, options => options.MapFrom(s => s.productType.name))
                .ForMember(d=>d.PictureUrl, options=> options.MapFrom<PictureURLResolver>()); 

            CreateMap<productBrand, BrandResultDto>();
            CreateMap<productType, TypeResultDto>();

        
        }
    }
}
