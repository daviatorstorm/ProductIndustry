using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SIENN.DbAccess;
using SIENN.DbAccess.Models;
using SIENN.Dto;

namespace SIENN.Services
{
    public class ProductService : Service<Product, ProductDto>, IProductService
    {
        public ProductService(IUnitOfWork uof) : base(uof)
        {
        }

        public IEnumerable<ProductDto> GetAllAvailable()
        {
            return Mapper.Map<IEnumerable<ProductDto>>(_uof.ProductRepository.GetAll().Where(x => x.IsAvailable).ToList());
        }
    }
}
