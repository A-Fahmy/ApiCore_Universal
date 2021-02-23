using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BTS.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetByCode(int entityId);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> filter = null);

        int Insert(T entity);
        
        void Update(T entity);
        
        void Delete(int entityId);

        List<T> ExcQuery(string Query, params object[] arr);
    }
}
