using CheckoutKataModels;
using CheckoutKataModels.Promotions;

namespace CheckoutKataPromotionProviderCreator
{
    public class NItemsPromotionCreator : PromotionCreator
    {
        public override Promotion CreatePromotion(int promotionType)
        {
            return (promotionType == 0) ? new NItemsPromotion() : promotionCreator?.CreatePromotion(promotionType);
        }
    }
}
