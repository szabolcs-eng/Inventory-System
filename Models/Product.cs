using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Models
{
    public class Product
    {
        public int Id { get; set; } // Unique identifier for the product
        public string Name { get; set; } // Name of the product
        public int Quantity { get; set; } // Quantity in stock
        public decimal Price { get; set; } // Price of the product
    }
}
