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

        public override Product Get(Guid id)
        {
            return _setWithIncludes.FirstOrDefault(x => x.Equals(id));
        }
    }
}
