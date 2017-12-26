using System;
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

        public override ProductDto Get(Guid id)
        {
            return Mapper.Map<ProductDto>(_uof.ProductRepository.Get(id));
        }

        public override IEnumerable<ProductDto> GetAll()
        {
            return Mapper.Map<IEnumerable<ProductDto>>(_uof.ProductRepository.GetAll());
        }

        public IEnumerable<ProductDto> GetAllAvailable()
        {
            return Mapper.Map<IEnumerable<ProductDto>>(_uof.ProductRepository.GetAll().Where(x => x.IsAvailable).ToList());
        }

        public override ProductDto Update(ProductDto entity)
        {
            var newEntity = _uof.ProductRepository.Update(Mapper.Map<Product>(entity));
            _uof.SaveChanges();
            return Mapper.Map<ProductDto>(newEntity);
        }
    }
}
