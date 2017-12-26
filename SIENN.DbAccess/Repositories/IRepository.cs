using SIENN.DbAccess.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SIENN.DbAccess.Repositories
{
    public interface IRepository<TEntity> where TEntity : CodeEntity
    {
        TEntity Get(Guid id);

        IQueryable<TEntity> GetFiltered<TFilter>(TFilter filter);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetRange(int start, int count);
        IQueryable<TEntity> GetRange(int start, int count, Expression<Func<TEntity, bool>> predicate);

        int Count();

        TEntity Add(TEntity entity);
        void Remove(TEntity entity);
    }
}
