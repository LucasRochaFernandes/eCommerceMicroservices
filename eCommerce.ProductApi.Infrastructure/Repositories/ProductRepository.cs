using eCommerce.ProductApi.Domain.Entities;
using eCommerce.SharedLibrary.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eCommerce.ProductApi.Infrastructure.Repositories;

public class ProductRepository : IGenericRepository<Product>
{
    private readonly ProductApiDbContext _dbContext;

    public ProductRepository(ProductApiDbContext context)
    {
        _dbContext = context;
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
        var entity = await _dbContext.Products.FindAsync(id);
        return entity;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _dbContext.Products.ToListAsync();
    }

    public async Task<Product?> GetByAsync(Expression<Func<Product, bool>> predicate)
    {
        var entity = await _dbContext.Products.FirstOrDefaultAsync(predicate);
        return entity;
    }

    public async Task UpdateAsync(Product entity)
    {
        _dbContext.Products.Update(entity);
        await _dbContext.SaveChangesAsync();
    }
}
