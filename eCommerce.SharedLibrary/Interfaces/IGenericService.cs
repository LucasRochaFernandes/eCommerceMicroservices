using eCommerce.SharedLibrary.Communication;
using System.Linq.Expressions;

namespace eCommerce.SharedLibrary.Interfaces;
public interface IGenericService<T> where T : class
{
    Task<ResponseFormat> CreateAsync(T entity);
    Task<ResponseFormat> UpdateAsync(T entity);
    Task<ResponseFormat> DeleteAsync(T entity);
    Task<T> FindByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByAsync(Expression<Func<T, bool>> predicate);
}
