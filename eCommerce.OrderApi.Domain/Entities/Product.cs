namespace eCommerce.OrderApi.Domain.Entities;
public class Product
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public decimal Price { get; set; }
    public int Stock { get; set; }
}
