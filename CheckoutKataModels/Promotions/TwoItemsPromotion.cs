using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutKataModels.Promotions
{
    public class TwoItemsPromotion : Promotion
    {
        public TwoItemsPromotion()
        {
            promotionType = PromotionType.TwoItemsPromotion;
        }
    }
}
