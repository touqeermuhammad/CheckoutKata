using CheckoutKataModels;
using CheckoutKataPromotionProviderCreator;

namespace CheckoutKataDataFeed
{
	public static class ActivePromotionCreators
	{
		public static PromotionCreator GetPromotionCreator()
		{
			PromotionCreator[] promotionCreators = new PromotionCreator[2] {
				new NItemsPromotionCreator(),
				new TwoItemsPromotionCreator()
			};

			for (int i = 0; i < promotionCreators.Length - 1; i++)
			{
				promotionCreators[i].SetNextPromotionCreator(promotionCreators[i + 1]);
			}

			return promotionCreators[0];
		}
	}
}
