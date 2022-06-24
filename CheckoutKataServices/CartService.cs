using CheckoutKataModels;
using CheckoutKataDiscountProviders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CheckoutKataServices
{
    public class CartService
    {
        private Cart cart;
        private DiscountProvider[] discountProviders;

        public CartService(DiscountProvider[] discountProviders)
        {
            this.cart = new Cart();
            this.discountProviders = discountProviders;
        }

        public void AddProduct(CartItem cartItem)
        {
            var item = cart.Where(x => x.Product.SKU == cartItem.Product.SKU).FirstOrDefault();

            if(item == null)
            {
                cart.Add(cartItem);
            }
            else
            {
                item.Quantity += cartItem.Quantity;
            }
        }

        public decimal CalculateTotal()
        {
            decimal totalPrices = 0;

            if (discountProviders?.Length > 0)
            {
                var promotionalItems = discountProviders.ToList().SelectMany(x=> x.Promtion.PromotionItems).ToList();

                decimal totalPriceOfNonPromotionalItems = cart.Where(x => promotionalItems.Where(y => y.SKU == x.Product.SKU).Count() == 0).Sum(x => x.Product.Price * x.Quantity);
                totalPrices = totalPriceOfNonPromotionalItems + discountProviders.ToList().Sum(x => x.ApplyPromotion(cart));
            }
            else
            {
                totalPrices = cart.Sum(x => x.Quantity * x.Product.Price);
            }

            return totalPrices;
        }
    }
}
