using Microsoft.EntityFrameworkCore;
using SIENN.DbAccess.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SIENN.DbAccess.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : CodeEntity
    {
        public DbSet<TEntity> _entities;

        public Repository(SIENNDbContext context)
        {
            _entities = context.Set<TEntity>();
        }

        public virtual TEntity Get(Guid id)
        {
            return _entities.AsNoTracking().FirstOrDefault(x => x.Code == id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _entities;
        }

        public virtual IQueryable<TEntity> GetRange(int start, int count)
        {
            return _entities.Skip(start).Take(count);
        }

        public virtual IQueryable<TEntity> GetRange(int start, int count, Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate).Skip(start).Take(count);
        }

        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate);
        }

        public virtual int Count()
        {
            return _entities.Count();
        }

        public virtual TEntity Add(TEntity entity)
        {
            return _entities.Add(entity).Entity;
        }

        public virtual void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public virtual IQueryable<TEntity> GetFiltered<TFilter>(TFilter filter)
        {
            return _entities;
        }
    }
}
