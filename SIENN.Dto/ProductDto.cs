using System;
using System.Collections.Generic;

namespace SIENN.Dto
{
    public class ProductDto : CodeEntityDto
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime DeliveryDate { get; set; }

        public ProductTypeDto Type { get; set; }
        public IEnumerable<ProductCategoryDto> Categories { get; set; }
        public ProductUnitDto Unit { get; set; }
    }
}
