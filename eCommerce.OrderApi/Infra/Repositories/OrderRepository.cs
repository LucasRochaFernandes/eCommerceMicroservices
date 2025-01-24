using eCommerce.OrderApi.Domain.Entities;
using eCommerce.OrderApi.Infrastructure.Database;
using eCommerce.SharedLibrary.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eCommerce.OrderApi.Infrastructure.Repositories;
public class OrderRepository : IGenericRepository<Order>
{
    private readonly OrderApiDbContext _dbContext;

    public OrderRepository(OrderApiDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> CreateAsync(Order entity)
    {
        var result = await _dbContext.Orders.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return result.Entity.Id;
    }

    public async Task DeleteAsync(Order entity)
    {
        _dbContext.Orders.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Order?> FindByIdAsync(Guid id)
    {
        var result = await _dbContext.Orders.FindAsync(id);
        return result;
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await _dbContext.Orders.ToListAsync();
    }

    public async Task<Order?> GetByAsync(Expression<Func<Order, bool>> predicate)
    {
        return await _dbContext.Orders
            .Include(order => order.User)
            .Include(order => order.OrderProducts)
                .ThenInclude(orderProd => orderProd.Product)
            .FirstOrDefaultAsync(predicate);
    }

    public async Task UpdateAsync(Order entity)
    {
        _dbContext.Orders.Update(entity);
        await _dbContext.SaveChangesAsync();
    }
}
