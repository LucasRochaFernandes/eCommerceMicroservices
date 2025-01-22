using AutoMapper;
using eCommerce.OrderApi.Domain.Entities;
using eCommerce.SharedLibrary.Messaging.Product;

namespace eCommerce.OrderApi.Communication.Profiles;
public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductCreatedMessage, Product>();
    }
}
