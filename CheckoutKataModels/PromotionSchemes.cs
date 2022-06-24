using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutKataModels
    public class PromotionSchemes
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int PromotionType { get; set; }
        public PromotionalItem[] Items { get; set; }
    }
}
