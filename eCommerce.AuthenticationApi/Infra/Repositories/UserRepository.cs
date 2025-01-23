using eCommerce.AuthenticationApi.Domain.Entities;
using eCommerce.SharedLibrary.Interfaces;
using System.Linq.Expressions;

namespace eCommerce.AuthenticationApi.Infra.Repositories;

public class UserRepository : IGenericRepository<User>
{
    public Task<Guid> CreateAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public Task<User?> FindByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByAsync(Expression<Func<User, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }
}
