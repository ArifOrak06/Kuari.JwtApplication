using System.Linq.Expressions;

namespace Kuari.JwtApplication.Back.Core.Application.İnterfaces
{
    public interface IRepository<T> where T : class, new()
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(object id); // Update işlemi için Tracking açık
        Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter); // asNoTracking ürün detayının listelenmesi durumlarında kullanılabilir.
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
