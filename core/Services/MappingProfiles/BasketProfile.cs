using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities.Basket;
using shared;

namespace Services.MappingProfiles
{
    partial class BasketProfile:Profile
    {
        public BasketProfile() { 
        CreateMap<CustomerBasket, BasketDto>().ReverseMap();
        CreateMap<BasketItem, BasketItemDto>().ReverseMap();
                }
    }
}
