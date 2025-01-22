using AutoMapper;
using eCommerce.OrderApi.Communication.Profiles;
using eCommerce.OrderApi.Communication.Requests;
using eCommerce.OrderApi.Domain.Entities;
using eCommerce.SharedLibrary.Interfaces;

namespace eCommerce.OrderApi.Application.Services;
public class CreateProductService
{
    private readonly IGenericRepository<Product> _productRepository;

    public CreateProductService(IGenericRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<Guid> Execute(CreateProductRequest request)
    {
        var mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ProductProfile>();
        }).CreateMapper();
        var productEntity = mapper.Map<Product>(request);
        var productId = await _productRepository.CreateAsync(productEntity);
        return productId;
    }
}
