using AutoMapper;
using eCommerce.ProductApi.Communication.Requests;
using eCommerce.ProductApi.Communication.Responses;
using eCommerce.ProductApi.Domain.Entities;

namespace eCommerce.ProductApi.Communication.Profiles;
public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductRequest, Product>();
        CreateMap<Product, ProductResponse>();
        CreateMap<Product, PubProductCreatedMessage>();
    }
}
