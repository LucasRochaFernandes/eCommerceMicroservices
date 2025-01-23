using eCommerce.OrderApi.Domain.Entities;
using eCommerce.SharedLibrary.Interfaces;
using eCommerce.SharedLibrary.Logging.Messages;
using eCommerce.SharedLibrary.Messaging.Product;
using MassTransit;

namespace eCommerce.OrderApi.Services;

public class SubProductStockUpdated : IConsumer<ProductStockUpdatedMessage>
{
    private readonly IGenericRepository<Product> _productRepository;

    public SubProductStockUpdated(IGenericRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Consume(ConsumeContext<ProductStockUpdatedMessage> context)
    {
        var message = context.Message;
        var product = await _productRepository.FindByIdAsync(message.ProductId);
        MessageReceived.LogMessage($"Product Stock Updated Message Caught - " +
            $"ProductId:{message!.ProductId}");
        if (product is not null)
        {
            product.Stock = message.NewStock;
            await _productRepository.UpdateAsync(product);
            MessageReceived.LogMessage($"New Stock to ProductId:{message!.ProductId}");
        }
    }
}
