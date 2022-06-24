using CheckoutKataModels;
using CheckoutKataModels.Promotions;
using CheckoutKataDiscountProviders;

namespace CheckoutKataDiscountProviderCreator
{
    public abstract class DiscountProviderCreator
    {
		protected DiscountProviderCreator discountProviderCreator;
		public void SetNextDiscountProvider(DiscountProviderCreator discountProviderCreator)
		{
			this.discountProviderCreator = discountProviderCreator;
		}
		public abstract DiscountProvider CreateDiscountProvider(Promotion promotion);
	}
}
