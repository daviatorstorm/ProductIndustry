using SIENN.DbAccess;
using SIENN.DbAccess.Models;
using SIENN.Dto;

namespace SIENN.Services
{
    public class ProductUnitService : Service<ProductUnit, ProductUnitDto>, IProductUnitService
    {
        public ProductUnitService(IUnitOfWork uof) : base(uof)
        {
        }
    }
}
