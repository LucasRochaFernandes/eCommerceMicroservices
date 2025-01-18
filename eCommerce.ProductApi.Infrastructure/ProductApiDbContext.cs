using eCommerce.ProductApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.ProductApi.Infrastructure;
public class ProductApiDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public ProductApiDbContext(DbContextOptions<ProductApiDbContext> options) : base(options)
    {
    }

}
