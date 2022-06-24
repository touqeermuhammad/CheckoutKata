using CheckoutKataModels;

namespace CheckoutKataDataFeed
{
    public class PromotionalSchemesData
    {
        public static PromotionSchemes[] GetPromotionSchemes()
        {
			PromotionSchemes[] promotionDetails = new PromotionSchemes[2] {
				new PromotionSchemes()
				{
					Name = "B",
					Price = 40,
					PromotionType = 0,
					Items = new PromotionalItem[1] {
						new PromotionalItem("B", 3)
					}
				},
				new PromotionSchemes()
				{
					Name = "D",
					Price = System.Convert.ToDecimal(82.5),
					PromotionType = 1,
					Items = new PromotionalItem[1] {						
						new PromotionalItem("D", 2)
					}
				}
			};

			return promotionDetails;
		}
    }
}
