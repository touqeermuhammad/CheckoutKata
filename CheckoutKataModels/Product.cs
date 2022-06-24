using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutKataModels
{
    public class Product
    {
        public Product(string sku, decimal price)
        {
            this.SKU = sku;
            this.Price = price;
        }

        public string SKU { get; set; }
        public decimal Price { get; set; }
    }
}
