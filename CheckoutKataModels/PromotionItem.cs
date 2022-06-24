using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutKataModels
{
    public class PromotionalItem
    {
        public PromotionalItem(string sku, int quantity)
        {
            this.SKU = sku;
            this.Quantity = quantity;
        }

        public string SKU { get; set; }
        public int Quantity { get; set; }
    }
}
