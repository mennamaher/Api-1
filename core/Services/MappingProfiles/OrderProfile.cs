using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities.OrderEntity;
using shared.OrderModule;

namespace Services.MappingProfiles
{
    public class OrderProfile:Profile
    {
        public OrderProfile() {

            #region shipping address

            CreateMap<shippingAddress, ShippingAddressDto>().ReverseMap();
            #endregion

            #region order item

            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(o => o.ProductId, p => p.MapFrom(p => p.Product.ProductId))
                .ForMember(o => o.ProductName, p => p.MapFrom(p => p.Product.ProductName))
                .ForMember(o => o.PictureUrl, p => p.MapFrom(p => p.Product.Pictureurl)).ReverseMap();

            #endregion

            #region order order result

            CreateMap<Order, OrderResultDto>()
                .ForMember(o => o.paymentSatuts, p => p.MapFrom(p => p.ToString()))
                .ForMember(o => o.DeliveryMethod, p => p.MapFrom(p => p.deliveryMethod.ShortName))
                .ForMember(o => o.total, p => p.MapFrom(p => p.SubTotal+ p.deliveryMethod.Price));
            #endregion

            #region delivery

            CreateMap<DeliveryMethod, DeliveryMethodDto>().ReverseMap();
            #endregion
        }

    }
}
