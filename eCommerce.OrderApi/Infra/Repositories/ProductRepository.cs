using eCommerce.OrderApi.Domain.Entities;
using eCommerce.OrderApi.Infrastructure.Database;
using eCommerce.SharedLibrary.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eCommerce.OrderApi.Infrastructure.Repositories;
public class ProductRepository : IGenericRepository<Product>
{
    private readonly OrderApiDbContext _dbContext;

    public ProductRepository(OrderApiDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> CreateAsync(Product entity)
    {
        var result = await _dbContext.Products.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return result.Entity.Id;
    }

    public async Task DeleteAsync(Product entity)
    {
        _dbContext.Products.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Product?> FindByIdAsync(Guid id)
    {
        var result = await _dbContext.Products.FindAsync(id);
        return result;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _dbContext.Products.ToListAsync();
    }

    public async Task<Product?> GetByAsync(Expression<Func<Product, bool>> predicate)
    {
        return await _dbContext.Products.FirstOrDefaultAsync(predicate);
    }

    public async Task UpdateAsync(Product entity)
    {
        _dbContext.Products.Update(entity);
        await _dbContext.SaveChangesAsync();
    }
}
