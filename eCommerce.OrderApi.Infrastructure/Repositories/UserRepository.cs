using eCommerce.OrderApi.Domain.Entities;
using eCommerce.OrderApi.Infrastructure.Database;
using eCommerce.SharedLibrary.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eCommerce.OrderApi.Infrastructure.Repositories;
public class UserRepository : IGenericRepository<User>
{
    private readonly OrderApiDbContext _dbContext;

    public UserRepository(OrderApiDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> CreateAsync(User entity)
    {
        var result = await _dbContext.Users.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return result.Entity.Id;
    }

    public async Task DeleteAsync(User entity)
    {
        _dbContext.Users.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<User?> FindByIdAsync(Guid id)
    {
        var result = await _dbContext.Users.FindAsync(id);
        return result;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _dbContext.Users.ToListAsync();
    }

    public async Task<User?> GetByAsync(Expression<Func<User, bool>> predicate)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(predicate);
    }

    public async Task UpdateAsync(User entity)
    {
        _dbContext.Users.Update(entity);
        await _dbContext.SaveChangesAsync();
    }
}
