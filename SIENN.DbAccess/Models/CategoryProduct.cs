using System;

namespace SIENN.DbAccess.Models
{
    public class CategoryProduct
    {
        public Guid ProductCode { get; set; }
        public Product Product { get; set; }

        public Guid CategoryCode { get; set; }
        public ProductCategory Category { get; set; }
    }
}
