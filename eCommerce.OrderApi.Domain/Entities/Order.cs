using eCommerce.OrderApi.Domain.Enums;

namespace eCommerce.OrderApi.Domain.Entities;
public class Order
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public User User { get; set; }
    public DateTime OrderDateTime { get; set; } = DateTime.UtcNow;
    public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
    public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;
    public ICollection<OrderProduct> OrderProducts { get; set; }
    public ICollection<Product> Products => OrderProducts.Select(op => op.Product).ToList();
}


