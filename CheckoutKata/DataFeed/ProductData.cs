using CheckoutKataModels;

namespace CheckoutKataDataFeed
{
    public static class ProductData
    {
        public static Product[] GetProducts()
        {
			Product[] products = new Product[]
			{
				new Product("A", 10),
				new Product("B", 15),
				new Product("C", 40),
				new Product("D", 55)

			};

			return products;
		}
    }
}
