using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SMJRegisterAPIV2.Common.Entities;
using SMJRegisterAPIV2.Database.Contexts;

namespace SMJRegisterAPIV2.Features.Common;

public class GenericRepository<T>(ApplicationDbContext context) : IGenericRepository<T>
    where T : BaseEntity
{
    public virtual async  Task<T> AddAsync(T entity)
    {
        await context.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }
    public virtual  async Task UpdateAsync(T entity, int id)
    {
        var entry = await context.Set<T>().FindAsync(id); 
        context.Entry(entry).CurrentValues.SetValues(entity);
        await context.SaveChangesAsync();
    }
    public virtual async Task DeleteAsync(T entity)
    {
        entity.IsDeleted = true;
        await context.SaveChangesAsync();
        await context.SaveChangesAsync();
    }
    public virtual async Task<List<T>> GetAllAsync(int pageNumber = 1 , int pageSize = 10)
    {
     return await context.Set<T>()
         .Skip((pageNumber-1)*pageSize)
         .Take(pageSize)
         .ToListAsync(); 
    } 

    public virtual  async Task<T> GetByIdAsync(int id)
    {
        if (await context.Set<T>().FindAsync(id) != null) 
            await context.Set<T>().FindAsync(id);
        return null;
    }
    public async Task LoadReferenceAsync<TProperty>(T entity, Expression<Func<T, TProperty>> navigationProperty)
        where TProperty : class
    {
        var entry = context.Entry(entity);
        await entry.Reference(navigationProperty).LoadAsync();
    }
}