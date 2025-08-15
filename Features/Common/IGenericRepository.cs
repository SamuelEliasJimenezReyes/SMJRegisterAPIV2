using System.Linq.Expressions;

namespace SMJRegisterAPI.Features.Common;

public interface IGenericRepository<T> where T : class
{
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity, int id);
    Task DeleteAsync(T entity);
    Task<List<T>> GetAllAsync(int pageNumber = 1 , int pageSize = 10);
    Task<T> GetByIdAsync(int id);
    Task LoadReferenceAsync<TProperty>(T entity, Expression<Func<T, TProperty>> navigationProperty)
        where TProperty : class;
}