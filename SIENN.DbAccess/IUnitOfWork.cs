using SIENN.DbAccess.Models;
using SIENN.DbAccess.Repositories;

namespace SIENN.DbAccess
{
    public interface IUnitOfWork
    {
        ProductRepository ProductRepository { get; }

        Repository<TEntity> GetRepository<TEntity>() where TEntity : CodeEntity;

        void SaveChanges();
    }
}