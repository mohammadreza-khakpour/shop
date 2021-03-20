﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Entities
{
    public enum Status
    {
        Insufficient,
        InOrder
    }
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int MinimumAmount { get; set; }
        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public HashSet<Warehouse> Warehouses { get; set; }
        public Status Status { get; set; }
    }
}
