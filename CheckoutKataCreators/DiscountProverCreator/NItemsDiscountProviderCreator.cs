using CheckoutKataModels;
using CheckoutKataModels.Promotions;
using CheckoutKataDiscountProviders;

using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutKataDiscountProviderCreator
{
    public class NItemsDiscountProviderCreator : DiscountProviderCreator
    {
        public override DiscountProvider CreateDiscountProvider(Promotion promotion)
        {
            return (promotion.PromotionType == PromotionType.NItemsPromotion) ? new NItemsDiscountProvider(promotion) : discountProviderCreator?.CreateDiscountProvider(promotion);
        }
    }
}
