using System;
using System.Collections.Generic;

#nullable disable

namespace Assignment3_PRN211.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? UnitsInStock { get; set; }
        public string Image { get; set; }
        public int? CategoryId { get; set; }
        public bool? Discontinued { get; set; }

        public virtual Category Category { get; set; }
    }
}
