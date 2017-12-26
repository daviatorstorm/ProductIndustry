using System;

namespace SIENN.Dto
{
    public class ProductFilter : Filter
    {
        public Guid? Type { get; set; }
        public Guid? Unit { get; set; }
        public Guid? Category { get; set; }
    }
}
