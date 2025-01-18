using System.Linq.Expressions;

namespace eCommerce.SharedLibrary.Interfaces;
public interface IGenericRepository<T> where T : class
{
    Task<Guid> CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<T?> FindByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByAsync(Expression<Func<T, bool>> predicate);
}
