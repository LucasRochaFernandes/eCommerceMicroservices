using AutoMapper;
using eCommerce.ProductApi.Communication.Profiles;
using eCommerce.ProductApi.Communication.Requests;
using eCommerce.ProductApi.Domain.Entities;
using eCommerce.SharedLibrary.Exceptions;
using eCommerce.SharedLibrary.Interfaces;

namespace eCommerce.ProductApi.Application.Services;
public class CreateProductService
{
    private readonly IGenericRepository<Product> _productRepository;

    public CreateProductService(IGenericRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<Product> Execute(ProductRequest request)
    {
        var mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ProductProfile>();
        }).CreateMapper();

        var productEntity = mapper.Map<Product>(request);
        var productAlreadyExists = await _productRepository.GetByAsync(p => p.Name == productEntity.Name);
        if (productAlreadyExists is not null)
        {
            throw new ConflictException("Product already exists");
        }
        await _productRepository.CreateAsync(productEntity);
        return productEntity;
    }
}
