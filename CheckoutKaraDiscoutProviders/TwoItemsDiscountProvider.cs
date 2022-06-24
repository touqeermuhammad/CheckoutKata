using CheckoutKataModels;
using CheckoutKataModels.Promotions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckoutKataDiscountProviders
{
    public class TwoItemsDiscountProvider : DiscountProvider
    {
        public TwoItemsDiscountProvider(Promotion promotion)
        {
            this.promotion = promotion;
        }
		public override decimal ApplyPromotion(Cart cart)
		{
			decimal totalPrice = 0;
			var cartItem = cart.Where(x => x.Product.SKU == promotion.PromotionItems[0].SKU).FirstOrDefault();

			if (cartItem != null && promotion.PromotionItems?.Length > 0)
			{
				decimal promotionPrice = promotion.PromotionPrice;
				int promotionQuantity = promotion.PromotionItems[0].Quantity;


				if (promotionQuantity > 0 && (promotionQuantity < cartItem.Quantity))
				{
					int noOfTimesPromotionApplies = cartItem.Quantity / promotionQuantity;
					int quantityPromotionNotApplied = cartItem.Quantity % promotionQuantity;

					totalPrice = (noOfTimesPromotionApplies * promotionPrice) + (quantityPromotionNotApplied * cartItem.Product.Price);
				}
				else
				{
					totalPrice = cartItem.Quantity * cartItem.Product.Price;
				}
			}

			return totalPrice;
		}
	}
}
