using Microsoft.EntityFrameworkCore;
using Mobilya.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Mobilya.Data.Concreat.EfCore
{
    public class EfGenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DbContext context;

        public EfGenericRepository(DbContext ctx)
        {
            context = ctx;
        }


        public T Add(T entity)
        {
            context.Set<T>().Add(entity);
            Save();
            return entity;
        }

        public T Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            Save();
            return entity;

        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }

        public T GetbyId(int id)
        {
            return context.Set<T>().Find(id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public T Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            Save();
            return entity;

        }
    }
}
