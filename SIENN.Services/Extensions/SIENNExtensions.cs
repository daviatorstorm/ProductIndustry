using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SIENN.DbAccess;
using SIENN.DbAccess.Models;
using SIENN.Dto;
using System.Linq;

namespace SIENN.Services.Extensions
{
    public static class SIENNExtensions
    {
        public static IServiceCollection AddSIENNServices(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // Inject services
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductUnitService, ProductUnitService>();
            services.AddTransient<IProductCategoryService, ProductCategoryService>();
            services.AddTransient<IProductTypeService, ProductTypeService>();

            // Mappings Model -> Dto
            services.AddMappings();

            return services;
        }

        public static IServiceCollection AddMappings(this IServiceCollection services)
        {
            Mapper.Initialize(cfg =>
            {
                // Simple Data Model -> Dto
                cfg.CreateMap<ProductType, ProductTypeDto>();
                cfg.CreateMap<ProductUnit, ProductUnitDto>();
                cfg.CreateMap<ProductCategory, ProductCategoryDto>();

                // Simple Data Dto -> Model
                cfg.CreateMap<ProductTypeDto, ProductType>();
                cfg.CreateMap<ProductUnitDto, ProductUnit>();
                cfg.CreateMap<ProductCategoryDto, ProductCategory>();

                cfg.CreateMap<Product, ProductDto>()
                    .ForMember(x => x.Categories, opts => opts.MapFrom(dest =>
                        dest.Categories.Select(x => new ProductCategoryDto { Code = x.CategoryCode, Name = x.Category != null ? x.Category.Name : string.Empty })));

                cfg.CreateMap<ProductDto, Product>()
                    .ForMember(x => x.Type, opts => opts.Ignore())
                    .ForMember(x => x.Unit, opts => opts.Ignore())
                    .ForMember(x => x.Categories, opts => opts.MapFrom(
                        dest => dest.Categories.Select(x =>
                            new CategoryProduct { CategoryCode = x.Code, ProductCode = dest.Code })));
            });

            return services;
        }
    }
}
