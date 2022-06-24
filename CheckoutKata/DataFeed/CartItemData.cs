using CheckoutKataModels;
using System.Collections.Generic;

namespace CheckoutKataDataFeed
{
    public static class CartItemData
    {
        public static IDictionary<string, int> GetCartAItems()
        {
            IDictionary<string, int> productWithQuantity = new Dictionary<string, int>();
            productWithQuantity.Add("A", 5);
            productWithQuantity.Add("B", 5);
            productWithQuantity.Add("C", 1);
            return productWithQuantity;
        }

        public static IDictionary<string, int> GetCartBItems()
        {
            IDictionary<string, int> productWithQuantity = new Dictionary<string, int>();
            productWithQuantity.Add("A", 5);
            productWithQuantity.Add("B", 5);
            productWithQuantity.Add("C", 1);
            productWithQuantity.Add("D", 1);
            return productWithQuantity;
        }

        public static IDictionary<string, int> GetCartCItems()
        {
            IDictionary<string, int> productWithQuantity = new Dictionary<string, int>();
            productWithQuantity.Add("A", 1);
            productWithQuantity.Add("B", 1);
            productWithQuantity.Add("C", 1);
            return productWithQuantity;
        }
    }
}
