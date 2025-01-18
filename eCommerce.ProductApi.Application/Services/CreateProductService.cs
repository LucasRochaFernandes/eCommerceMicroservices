using AutoMapper;
using eCommerce.ProductApi.Communication.Requests;
using eCommerce.ProductApi.Domain.Entities;
using eCommerce.SharedLibrary.Exceptions;
using eCommerce.SharedLibrary.Interfaces;

namespace eCommerce.ProductApi.Application.Services;
public class CreateProductService
{
    private readonly IGenericRepository<Product> _productRepository;
    private readonly IMapper _mapper;

    public CreateProductService(IGenericRepository<Product> productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public async Task<Guid> Execute(ProductRequest product)
    {
        var productEntity = _mapper.Map<ProductRequest, Product>(product);
        var productAlreadyExists = await _productRepository.GetByAsync(p => p.Name == productEntity.Name);
        if (productAlreadyExists is not null)
        {
            throw new ConflictException("Product already exists");
        }
        return await _productRepository.CreateAsync(productEntity);
    }
}
