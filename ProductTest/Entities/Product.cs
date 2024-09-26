using System;
using System.Collections.Generic;

namespace ProductTest.Entities
{
    public partial class Product
    {
        public int Upc { get; set; }
        public string? Description { get; set; }
        public decimal CurrentPrice { get; set; }
        public int Quantity { get; set; }
    }
}
