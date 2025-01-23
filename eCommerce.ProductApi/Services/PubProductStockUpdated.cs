using eCommerce.SharedLibrary.Messaging.Product;
using MassTransit;

namespace eCommerce.ProductApi.Services;

public class PubProductStockUpdated
{
    private readonly IBus _bus;

    public PubProductStockUpdated(IBus bus)
    {
        _bus = bus;
    }

    public async Task Execute(Guid productId, int newStock)
    {
        await _bus.Publish(new ProductStockUpdatedMessage
        (
           productId,
           newStock
        ));
    }
}
