using AutoMapper;
using eCommerce.OrderApi.Communication.Profiles;
using eCommerce.OrderApi.Domain.Entities;
using eCommerce.SharedLibrary.Interfaces;
using eCommerce.SharedLibrary.Logging.Messages;
using eCommerce.SharedLibrary.Messaging.Product;
using MassTransit;

namespace eCommerce.OrderApi.Services;

public class SubProductCreatedService : IConsumer<ProductCreatedMessage>
{
    private readonly IGenericRepository<Product> _productRepository;

    public SubProductCreatedService(IGenericRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Consume(ConsumeContext<ProductCreatedMessage> context)
    {
        var message = context.Message;
        MessageReceived.LogMessage($"Catched {message!.Id}");

        await Task.Delay(5000);

        var mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ProductProfile>();
        }).CreateMapper();
        var productEntity = mapper.Map<Product>(message);
        var productAlreadyExists = await _productRepository.FindByIdAsync(productEntity.Id); 
        if (productAlreadyExists != null)
        {
            MessageReceived.LogMessage($"Product {productEntity.Id} already exists");
        }
        else
        {
            await _productRepository.CreateAsync(productEntity);
            MessageReceived.LogMessage($"New Product {productEntity.Id}");
        }
    }
}
