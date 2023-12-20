using Api.DAL;
using Api.Entities;
using Api.Entities.Base;
using System.Linq.Expressions;

namespace Api.Repositories.Abstraction
{
    public interface IRepository<T> where T : BaseEntity 
    {
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null, params string[]? includes);
        Task<T> GetById(int id);
        Task Create(T entity);
        Task Update(T entity);
        void Delete(T entity);
        Task SaveChangesAsync();

    }
}
