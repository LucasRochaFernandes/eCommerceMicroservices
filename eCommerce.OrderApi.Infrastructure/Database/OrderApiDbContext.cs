using eCommerce.OrderApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.OrderApi.Infrastructure.Database;
public class OrderApiDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public OrderApiDbContext(DbContextOptions<OrderApiDbContext> options) : base(options)
    {
    }
}
