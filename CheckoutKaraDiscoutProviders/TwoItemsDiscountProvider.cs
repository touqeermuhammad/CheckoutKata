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
			decimal totalPriceOfItemsNotSatisfiedPromotion = 0;

			CartItem[] cartItems = cart.Where(x => promotion.PromotionItems.Where(y => (y.SKU == x.Product.SKU) && (y.Quantity <= x.Quantity)).Count() > 0).ToArray();

			if (cartItems.Length == promotion.PromotionItems.Length)
			{
				decimal promotionPrice = promotion.PromotionPrice;
				int noOfTimesPromotionApplies = 0;

				foreach (var cartItem in cartItems)
				{
					var promotedItem = promotion.PromotionItems.Where(x => x.SKU == cartItem.Product.SKU).FirstOrDefault();
					int noOfTimesPromotionAppliesForTheItem = 0;

					if (promotedItem != null)
					{
						noOfTimesPromotionAppliesForTheItem = cartItem.Quantity / promotedItem.Quantity;
						totalPriceOfItemsNotSatisfiedPromotion += (cartItem.Quantity % promotedItem.Quantity) * cartItem.Product.Price;

						if (noOfTimesPromotionApplies == 0 || (noOfTimesPromotionApplies > noOfTimesPromotionAppliesForTheItem))
						{
							noOfTimesPromotionApplies = noOfTimesPromotionAppliesForTheItem;
						}
					}
				}

				totalPrice = totalPriceOfItemsNotSatisfiedPromotion + (noOfTimesPromotionApplies * promotion.PromotionPrice);
			}
			else
			{
				totalPrice = cartItems.Sum(x => x.Quantity * x.Product.Price);
			}

			return totalPrice;
		}
    }
}
