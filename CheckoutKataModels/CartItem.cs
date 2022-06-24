using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutKataModels
{
    public class CartItem
    {
        public CartItem(Product product, int quantity)
        {
            this.Product = product;
            this.Quantity = quantity;
        }

        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
