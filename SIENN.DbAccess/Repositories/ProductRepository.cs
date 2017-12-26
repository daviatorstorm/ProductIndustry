using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SIENN.DbAccess.Models;
using SIENN.Dto;

namespace SIENN.DbAccess.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly IIncludableQueryable<Product, ProductUnit> _setWithIncludes;

        public ProductRepository(SIENNDbContext context) : base(context)
        {
            _setWithIncludes = _entities
                .Include(x => x.Categories).ThenInclude(x => x.Category)
                .Include(x => x.Type)
                .Include(x => x.Unit);
        }

        public override IQueryable<Product> GetAll() => _setWithIncludes;

        public override IQueryable<Product> GetFiltered<TFilter>(TFilter filter)
        {
            var newFilter = filter as ProductFilter;
            var source = _entities.AsQueryable();

            if (newFilter.Category.HasValue)
            {
                source = source.Where(x => x.Categories.Any(y => y.CategoryCode == newFilter.Category.Value));
            }
            if (newFilter.Category.HasValue)
            {
                source = source.Where(x => x.TypeCode == newFilter.Type.Value);
            }
            if (newFilter.Category.HasValue)
            {
                source = source.Where(x => x.UnitCode == newFilter.Unit.Value);
            }

            return source;
        }

        public override Product Update(Product entity)
        {
            var newIds = entity.Categories.Select(x => x.CategoryCode);
            var categoriesToDelete = _context.Set<CategoryProduct>().Where(x => !newIds.Contains(x.CategoryCode)).ToList();
            entity.Categories = entity.Categories.Where(x => !categoriesToDelete.Select(y => y.CategoryCode).Contains(x.CategoryCode)).ToList();

            _context.RemoveRange(categoriesToDelete);
            _context.Set<CategoryProduct>().AddRange(entity.Categories);

            return base.Update(entity);
        }

        public override Product Get(Guid id)
        {
            return _setWithIncludes.FirstOrDefault(x => x.Code == id);
        }
    }
}
