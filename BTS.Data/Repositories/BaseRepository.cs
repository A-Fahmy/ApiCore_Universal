using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Data;
using BTS.Data.Interfaces;

namespace BTS.Data.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        #region Properties
        protected DbContext DbContext { get; set; }
        protected DbSet<T> DbSet { get; set; }
        #endregion

        #region Constructor
        public BaseRepository()
        {
            DbContext = new RiseDBEntities();
            DbSet = DbContext.Set<T>();
        }
        #endregion

        #region Methods
        public virtual T GetByCode(int Code)
        {
            return DbSet.Find(Code);
        }

        public virtual IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public virtual IQueryable<T> GetActiveList()
        {
            IQueryable<T> lst = DbSet;
            List<T> lstActive = new List<T>();
            foreach (T obj in lst)
            {
                if (obj.GetType().GetProperty("IsActive").GetValue(obj, null).ToString() == "True")
                    lstActive.Add(obj);  
            }
            return lstActive.AsQueryable();
        }

        public IQueryable<T> GetWhere(System.Linq.Expressions.Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query;
        }

        public virtual int Insert(T entity)
        {
            try
            {
                DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
                if (dbEntityEntry.State != EntityState.Detached)
                {
                    dbEntityEntry.State = EntityState.Added;
                }
                else
                {
                    DbSet.Add(entity);
                }
                DbContext.SaveChanges();
                return int.Parse(dbEntityEntry.Property("Code").CurrentValue.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual void Update(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
            DbContext.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
            DbContext.SaveChanges();
        }
        public virtual void Delete(int Code)
        {
            var entity = GetByCode(Code);
            if (entity == null) return; // not found; assume already deleted.
            Delete(entity);
        }

        public virtual List<T> ExcQuery(string Query,params object[]arr)
        {
            List<T> lst = DbContext.Database.SqlQuery<T>(Query, arr).ToList();
            return lst;
        }
       
        public int ExecuteSqlCommand(string Query, params object[] arr)
        {
            return DbContext.Database.ExecuteSqlCommand(Query, arr);
        }

        #endregion
    }
}
