using System.Linq.Expressions;

namespace Boitoan.DAL.Abstraction;

public interface IRepository<T> where T : class
{
    Task<T?> GetByIdAsync(string id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> FindAsync(Expression<Func<T, bool>> predicate);
    Task<long> Count();
    Task AddAsync(T entity);
    Task UpdateAsync(string id, T entity);
    Task DeleteAsync(string id);
    Task SaveChangesAsync();
}
