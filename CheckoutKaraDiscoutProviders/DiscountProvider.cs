using CheckoutKataModels;
using CheckoutKataModels.Promotions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutKataDiscountProviders
{
    public abstract class DiscountProvider
    {
        protected Promotion promotion;
        public abstract decimal ApplyPromotion(Cart cart);

        public Promotion Promtion
        {
            get
            {
                return promotion;
            }
        }
    }
}
