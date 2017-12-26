using System;
using System.Collections.Generic;

namespace SIENN.DbAccess.Models
{
    public class Product : CodeEntity
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime DeliveryDate { get; set; }

        public Guid TypeCode { get; set; }
        public ProductType Type { get; set; }

        public Guid UnitCode { get; set; }
        public ProductUnit Unit { get; set; }

        public IEnumerable<CategoryProduct> Categories { get; set; }
    }
}
