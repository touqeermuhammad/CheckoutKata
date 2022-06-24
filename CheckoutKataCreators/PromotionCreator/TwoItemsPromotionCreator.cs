using CheckoutKataModels;
using CheckoutKataModels.Promotions;

namespace CheckoutKataPromotionProviderCreator
{
    public class TwoItemsPromotionCreator : PromotionCreator
    {
        public override Promotion CreatePromotion(int promotionType)
        {
            return (promotionType == 1) ? new TwoItemsPromotion() : promotionCreator?.CreatePromotion(promotionType);
        }
    }
}
