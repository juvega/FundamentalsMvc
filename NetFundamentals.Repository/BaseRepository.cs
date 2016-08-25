using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;

namespace NetFundamentals.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private ChinookContext context;
        public BaseRepository()
        {
            context = new ChinookContext();
        }
        public int Add(T entity)
        {
            context.Entry(entity).State = EntityState.Added;
            return context.SaveChanges();
        }

        public int Delete(T entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
            return context.SaveChanges();
        }
        
        public int Update(T entity)
        {
            context.Entry(entity).State =EntityState.Modified;
            return context.SaveChanges();
        }
        public T GetById(Expression<Func<T, bool>> match)
        {
            return context.Set<T>().FirstOrDefault(match);
        }

        public IEnumerable<T> GetList()
        {
            return context.Set<T>();
        }

    }
}
