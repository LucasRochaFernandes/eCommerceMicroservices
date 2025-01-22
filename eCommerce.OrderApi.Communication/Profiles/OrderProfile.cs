using AutoMapper;
using eCommerce.OrderApi.Communication.Requests;
using eCommerce.OrderApi.Communication.Responses;
using eCommerce.OrderApi.Domain.Entities;

namespace eCommerce.OrderApi.Communication.Profiles;
public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderDetailsResponse>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
            .ForMember(dest => dest.CEP, opt => opt.MapFrom(src => src.User.CEP))
            .ForMember(dest => dest.OrderDateTime, opt => opt.MapFrom(src => src.OrderDateTime))
            .ForMember(dest => dest.FullAddress, opt => opt.MapFrom(src => src.User.FullAddress))
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.OrderProducts.Select(
                prod => new ProductOrderResponse(prod.ProductId, prod.Quantity))))
            .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.OrderProducts.Select(
                prod => prod.Product.Price * prod.Quantity).Sum()));

        CreateMap<CreateOrderRequest, Order>()
            .ForMember(dest => dest.OrderProducts, opt => opt.MapFrom(src => src.Products));
        CreateMap<ProductOrderRequest, OrderProduct>();

        CreateMap<Order, OrderCreatedResponse>()
            .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Id));


    }
}
