using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Mobilya.Data.Abstract
{
    public interface IGenericRepository<T>  where T: class
    {
        T GetbyId(int id);
        IQueryable<T> GetAll();
        IQueryable<T> Find(Expression<Func<T,bool>> predicate);
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
        void Save();
    }
}
