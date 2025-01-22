using AutoMapper;
using eCommerce.ProductApi.Communication.Profiles;
using eCommerce.ProductApi.Domain.Entities;
using eCommerce.SharedLibrary.Messaging.Product;
using MassTransit;

namespace eCommerce.ProductApi.Services;

public class PubProductCreatedService
{
    private readonly IBus _bus;

    public PubProductCreatedService(IBus bus)
    {
        _bus = bus;
    }

    public async Task Execute(Product request)
    {
        var mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ProductProfile>();
        }).CreateMapper();
        var message = mapper.Map<ProductCreatedMessage>(request);
        await _bus.Publish(message);
    }
}
