using eCommerce.ProductApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.ProductApi.Infrastructure;
public class ProductApiDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DbSet<Product> Products { get; set; }
    public ProductApiDbContext(IServiceProvider serviceProvider, DbContextOptions<ProductApiDbContext> options)
    : base(options)
    {
        _configuration = serviceProvider.GetRequiredService<IConfiguration>();
    }

    // Create a function OnConfiguring from Entity Framework with IConfiguration parameter
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

    }


}
