using InvictusFC.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvictusFC.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }
    public class Repository<T> : IRepository<T>
    where T : class
    {
        private readonly InvictusContext context;
        public Repository(InvictusContext context)
        {
            this.context = context;
        }
        public IEnumerable<T> GetAll()
        {
            return context.Set<T>();
        }
        public async Task<T> Add(T entity)
        {
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        public async Task<T> Delete(int id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        public async Task<T> Get(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }
        public async Task<T> Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }
    }
}