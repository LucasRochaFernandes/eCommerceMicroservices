using eCommerce.OrderApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.OrderApi.Infrastructure.Database;
public class OrderApiDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public OrderApiDbContext(IServiceProvider serviceProvider, DbContextOptions<OrderApiDbContext> options)
    : base(options)
    {
        _configuration = serviceProvider.GetRequiredService<IConfiguration>();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

    }
}
