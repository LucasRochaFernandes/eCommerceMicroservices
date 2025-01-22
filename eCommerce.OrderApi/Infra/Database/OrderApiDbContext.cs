using eCommerce.OrderApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderId, op.ProductId });

        modelBuilder.Entity<OrderProduct>()
            .HasOne(op => op.Order)
            .WithMany(o => o.OrderProducts)
            .HasForeignKey(op => op.OrderId);

        modelBuilder.Entity<OrderProduct>()
            .HasOne(op => op.Product)
            .WithMany()
            .HasForeignKey(op => op.ProductId);

        modelBuilder.Entity<OrderProduct>()
           .HasOne(op => op.Product)
           .WithMany()
           .HasForeignKey(op => op.ProductId);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId);

        modelBuilder.Entity<Order>()
            .Property(o => o.OrderStatus)
            .HasConversion<string>();

        modelBuilder.Entity<Order>()
            .Property(o => o.PaymentStatus)
            .HasConversion<string>();
    }
}
