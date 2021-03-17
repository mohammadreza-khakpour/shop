using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Entities
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Product> Products { get; set; }

    }
}
