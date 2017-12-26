using SIENN.DbAccess.Models;
using SIENN.Dto;
using System.Collections.Generic;

namespace SIENN.Services
{
    public interface IProductService : IService<Product, ProductDto>
    {
        IEnumerable<ProductDto> GetAllAvailable();
    }
}
