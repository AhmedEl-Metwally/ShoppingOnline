using AutoMapper;
using Shopping_online.Models;
using ShoppingOnline.Dtos;
using ShoppingOnline.Models;
using ShoppingOnline.OrderAggreate;
using ShoppingOnline.Services.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Address = ShoppingOnline.Services.Identity.Address;

namespace ShoppingOnline.Helpers
{
    public class MappingProfilescs : Profile
    {
        public MappingProfilescs()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.ProductBrand, opt => opt.MapFrom(src => src.ProductBrand.Name))
                .ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.ProductType.Name))
                .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom<ProuductUrl>()).ReverseMap();

            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<CustomerBasket, CustomerBasketDto>().ReverseMap();
            CreateMap<BasketItem, BasketItemDto>().ReverseMap();

            CreateMap<Order, OrderToReturnDto>()
                .ForMember(dest => dest.DeliveryMethod, opt => opt.MapFrom(src => src.DeliveryMethod.ShortName))
                .ForMember(dest => dest.DeliveryMethod, opt => opt.MapFrom(src => src.DeliveryMethod.Price)).ReverseMap();

            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(dest => dest.productId, opt => opt.MapFrom(src => src.ItemOrdered.ProductItemId))
                .ForMember(dest => dest.productName, opt => opt.MapFrom(src => src.ItemOrdered.ProductName))
                .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom(src => src.ItemOrdered.PictureUrl))
                .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom<OrderItemUrlResolver>()).ReverseMap();

        }
    }
}
