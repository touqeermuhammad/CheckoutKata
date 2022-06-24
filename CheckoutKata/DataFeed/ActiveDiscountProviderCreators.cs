using CheckoutKataModels;
using CheckoutKataDiscountProviderCreator;

namespace CheckoutKataDataFeed
{
    public static class ActiveDiscountProviderCreators
    {
		public static DiscountProviderCreator GetDiscountProviderCreator()
		{
			DiscountProviderCreator[] discountProviderCreators = new DiscountProviderCreator[2] {
				new NItemsDiscountProviderCreator(),
				new TwoItemsDiscountProviderCreator()
			};


			for (int i = 0; i < discountProviderCreators.Length - 1; i++)
			{
				discountProviderCreators[i].SetNextDiscountProvider(discountProviderCreators[i + 1]);
			}

			return discountProviderCreators[0];
		}
	}
}
