using SIENN.DbAccess;
using SIENN.DbAccess.Models;
using SIENN.Dto;

namespace SIENN.Services
{
    public class ProductCategoryService : Service<ProductCategory, ProductCategoryDto>, IProductCategoryService
    {
        public ProductCategoryService(IUnitOfWork uof) : base(uof)
        {
        }
    }
}
