using NUnit.Framework;
using CheckoutKataModels;
using CheckoutKataModels.Promotions;
using CheckoutKataDiscountProviders;
using CheckoutKataDiscountProviderCreator;
using CheckoutKataServices;
using CheckoutKataPromotionProviderCreator;

using System;
using System.Linq;
using CheckoutKataDataFeed;

namespace CheckoutKaraTest
{
    public class DiscountProviderTest
    {
        private PromotionCreator promotionCreator;
        private PromotionSchemes[] promotionDetails;
        private DiscountProviderCreator discountProviderCreator;

        [SetUp]
        public void Setup()
        {
            promotionCreator = ActivePromotionCreators.GetPromotionCreator();
            promotionDetails = PromotionalSchemesData.GetPromotionSchemes();

            discountProviderCreator = ActiveDiscountProviderCreators.GetDiscountProviderCreator();


        }
        private Promotion CreatePromotion(PromotionSchemes promotionDetail)
        {
            Promotion promption = promotionCreator.CreatePromotion(promotionDetail.PromotionType);
            promption.PromotionName = promotionDetail.Name;
            promption.PromotionPrice = promotionDetail.Price;
            promption.PromotionItems = promotionDetail.Items.Select(x => new PromotionalItem(x.SKU, x.Quantity)).ToArray();
            return promption;
        }

        [Test]
        public void NItemsPromotionProviderTest()
        {
            var promotions = promotionDetails.Where(x => x.PromotionType == (int)Enum.Parse(typeof(PromotionType), "NItemsPromotion")).Select(x => this.CreatePromotion(x)).ToList();
            var discountProviders = promotions.Select(x => discountProviderCreator.CreateDiscountProvider(x)).ToArray();
            var products = ProductData.GetProducts().ToList();
            var cartData = CartItemData.GetCartBItems().ToList();

            CartService cartService = new CartService(discountProviders);
            foreach (var x in cartData)
            {
                var prod = products.Where(y => y.SKU == x.Key).FirstOrDefault();

                if (prod != null)
                {
                    cartService.AddProduct(new CartItem(prod, x.Value));
                }
            }

            Assert.AreEqual(175, cartService.CalculateTotal());
        }

        [Test]
        public void TwoItemsPromotionProviderTest()
        {
            var promotions = promotionDetails.Where(x => x.PromotionType == (int)Enum.Parse(typeof(PromotionType), "TwoItemsPromotion")).Select(x => this.CreatePromotion(x)).ToList();
            var discountProviders = promotions.Select(x => discountProviderCreator.CreateDiscountProvider(x)).ToArray();
            var products = ProductData.GetProducts().ToList();
            var cartData = CartItemData.GetCartCItems().ToList();

            CartService cartService = new CartService(discountProviders);
            foreach (var x in cartData)
            {
                var prod = products.Where(y => y.SKU == x.Key).FirstOrDefault();

                if (prod != null)
                {
                    cartService.AddProduct(new CartItem(prod, x.Value));
                }
            }

            Assert.AreEqual(285, cartService.CalculateTotal());
        }

        [Test]
        public void AllPromotionProviderTest()
        {
            var promotions = promotionDetails.Select(x => this.CreatePromotion(x)).ToList();
            var discountProviders = promotions.Select(x => discountProviderCreator.CreateDiscountProvider(x)).ToArray();
            var products = ProductData.GetProducts().ToList();
            var cartData = CartItemData.GetCartDItems().ToList();

            CartService cartService = new CartService(discountProviders);
            foreach (var x in cartData)
            {
                var prod = products.Where(y => y.SKU == x.Key).FirstOrDefault();

                if (prod != null)
                {
                    cartService.AddProduct(new CartItem(prod, x.Value));
                }
            }

            Assert.AreEqual(325, cartService.CalculateTotal());
        }

        [Test]
        public void NoPromotionTest()
        {
            var promotions = promotionDetails.Select(x => this.CreatePromotion(x)).ToList();
            var discountProviders = promotions.Select(x => discountProviderCreator.CreateDiscountProvider(x)).ToArray();
            var products = ProductData.GetProducts().ToList();
            var cartData = CartItemData.GetCartAItems().ToList();

            CartService cartService = new CartService(discountProviders);
            foreach (var x in cartData)
            {
                var prod = products.Where(y => y.SKU == x.Key).FirstOrDefault();

                if (prod != null)
                {
                    cartService.AddProduct(new CartItem(prod, x.Value));
                }
            }

            Assert.AreEqual(120, cartService.CalculateTotal());
        }

    }

}