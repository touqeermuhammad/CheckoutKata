using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutKataModels.Promotions
{
    public abstract class Promotion
    {
        protected PromotionType promotionType;

        public string PromotionName { get; set; }
        public decimal PromotionPrice { get; set; }
        public PromotionalItem[] PromotionItems { get; set; }
        public PromotionType PromotionType
        {
            get
            {
                return promotionType;
            }
        }
    }

    public enum PromotionType
    {
        NItemsPromotion = 0,
        TwoItemsPromotion = 1
    }
}
