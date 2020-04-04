using InvictusFC.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InvictusFC.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        T Get(Guid id);
        T Add(T entity);
        T Update(T entity);
        T Delete(Guid id);
    }
    public class Repository<T> : IRepository<T>
    where T : class
    {
        private readonly InvictusContext context;
        public Repository(InvictusContext context)
        {
            this.context = context;
        }
        public IEnumerable<T> Get()
        {
            return context.Set<T>();
        }
        public T Add(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
            return entity;
        }
        public T Delete(Guid id)
        {
            var entity = context.Set<T>().Find(id);
            if (entity == null)
            {
                return entity;
            }
            context.Set<T>().Remove(entity);
            context.SaveChanges();
            return entity;
        }
        public T Get(Guid id)
        {
            return context.Set<T>().Find(id);
        }
        public T Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return entity;
        }
        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            var query = context.Set<T>().AsQueryable();
            return query.Where(predicate);
        }
    }
}