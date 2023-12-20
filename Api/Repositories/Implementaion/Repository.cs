using Api.DAL;
using Api.Entities; 
using Api.Entities.Base;
using Api.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Api.Repositories.Implementaion
{
    public class Repository<T> : IRepository<T> where T : BaseEntity  
    {
        private readonly AppDbContext _db;
        private readonly DbSet<T> _table;

        public Repository(AppDbContext db)
        {
            _db = db;
            _table = _db.Set<T>();  
        }

        public async Task Create(T brand)
        {
            await _db.Set<T>().AddAsync(brand);
        }

        public void Delete(T brand)
        {
            _db.Set<T>().Remove(brand);
        }

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null,params string[]? includes)
        {
            IQueryable<T> brands =  _db.Set<T>();
            if(expression is not null)
            {
                brands= brands.Where(expression);
            }
            if(includes is not null) 
            {
                for (int i = 0; i < includes.Length; i++)
                {
                    brands = brands.Include(includes[i]);
                }
            }
            return brands;
        }

        public async Task<T> GetById(int id)
        {
            return await _db.Set<T>().AsNoTracking().FirstOrDefaultAsync(c=>c.Id == id);
           
        }

        public async Task SaveChangesAsync()
        {
           await _db.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _db.Set<T>().Update(entity);
        }
    }
}
