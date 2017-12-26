using SIENN.DbAccess;
using SIENN.DbAccess.Models;
using SIENN.Dto;

namespace SIENN.Services
{
    public class ProductTypeService : Service<ProductType, ProductTypeDto>, IProductTypeService
    {
        public ProductTypeService(IUnitOfWork uof) : base(uof)
        {
        }
    }
}
