using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutKataModels.Promotions
{
    public class NItemsPromotion : Promotion
    {
        public NItemsPromotion()
        {
            promotionType = PromotionType.NItemsPromotion;
        }
    }
}
