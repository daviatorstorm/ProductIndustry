using SIENN.DbAccess.Models;
using SIENN.DbAccess.Repositories;

namespace SIENN.DbAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SIENNDbContext _context;
        private ProductRepository _productRepository;

        public UnitOfWork(SIENNDbContext context)
        {
            _context = context;
        }

        public ProductRepository ProductRepository
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository(_context);
                }

                return _productRepository;
            }
        }

        public Repository<TEntity> GetRepository<TEntity>() where TEntity : CodeEntity
        {
            return new Repository<TEntity>(_context);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
