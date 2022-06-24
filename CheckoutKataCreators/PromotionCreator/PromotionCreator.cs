using CheckoutKataModels;
using CheckoutKataModels.Promotions;

namespace CheckoutKataPromotionProviderCreator
{
    public abstract class PromotionCreator
    {
		protected PromotionCreator promotionCreator;

		public void SetNextPromotionCreator(PromotionCreator promotionCreator)
		{
			this.promotionCreator = promotionCreator;
		}

		public abstract Promotion CreatePromotion(int promotionType);
	}
}
