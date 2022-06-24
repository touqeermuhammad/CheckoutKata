using CheckoutKataModels;
using CheckoutKataModels.Promotions;
using CheckoutKataDiscountProviders;

namespace CheckoutKataDiscountProviderCreator
{
    public class TwoItemsDiscountProviderCreator : DiscountProviderCreator
    {
        public override DiscountProvider CreateDiscountProvider(Promotion promotion)
        {
            return (promotion.PromotionType == PromotionType.TwoItemsPromotion) ? new TwoItemsDiscountProvider(promotion) : discountProviderCreator?.CreateDiscountProvider(promotion);
        }
    }
}
