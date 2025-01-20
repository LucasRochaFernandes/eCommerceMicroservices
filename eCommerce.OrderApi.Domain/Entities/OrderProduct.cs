namespace eCommerce.OrderApi.Domain.Entities;
public class OrderProduct
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    public Guid OrderId { get; set; }
    public Order Order { get; set; }
    public int Quantity { get; set; }
}

//modelBuilder.Entity<OrderProduct>()
//        .HasKey(op => new { op.OrderId, op.ProductId }); // Configura chave composta

//modelBuilder.Entity<OrderProduct>()
//    .HasOne(op => op.Order) // Configura relacionamento com Order
//    .WithMany(o => o.OrderProducts) // Assumindo que Order possui uma coleção de OrderProducts
//    .HasForeignKey(op => op.OrderId);

//modelBuilder.Entity<OrderProduct>()
//    .HasOne(op => op.Product) // Configura relacionamento com ProductReference
//    .WithMany() // Assumindo que ProductReference não tem uma coleção de OrderProducts
//    .HasForeignKey(op => op.ProductId);
