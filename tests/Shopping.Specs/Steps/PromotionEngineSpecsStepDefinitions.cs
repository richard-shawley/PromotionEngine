using FluentAssertions;
using Shopping.Domain.Entities;
using Shopping.Domain.Models;
using Shopping.Specs.Context;
using TechTalk.SpecFlow;

namespace Shopping.Specs
{
    [Binding]
    public class PromotionEngineSpecsStepDefinitions
    {
        private readonly PromotionEngineContext _promotionEngineContext;

        public PromotionEngineSpecsStepDefinitions(PromotionEngineContext promotionEngineContext)
        {
            _promotionEngineContext = promotionEngineContext;
        }

        [Given(@"product '(.*)' costs '(.*)'")]
        public void GivenProductCosts(string sku, decimal price)
        {
            _promotionEngineContext.Products.Add(
                new Product
                {
                    Sku = sku,
                    Price = price
                });
        }

        [Given(@"there is a promotion for '(.*)' of product '(.*)' costing '(.*)'")]
        public void GivenThereIsAPromotionForOfProductCosting(int quantity, string sku, decimal price)
        {

            var promotionCriteria = CreatePromotionCriteria(quantity, sku);

            _promotionEngineContext.Promotions.Add(new MultiProductPromotion
            {
                PromotionCriteria = new List<PromotionCriteria> {
                    promotionCriteria
                },
                Price = price
            });
        }

        [Given(@"there is a promotion for products '(.*)' costing '(.*)'")]
        public void GivenThereIsAPromotionForProductsCosting(string skuList, decimal price)
        {
            var skus = Array.ConvertAll(skuList.Split(','), p => p.Trim());
            var promotionCriteria = new List<PromotionCriteria>();

            foreach (var sku in skus)
            {
                promotionCriteria.Add(CreatePromotionCriteria(1, sku));
            }

            _promotionEngineContext.Promotions.Add(new MultiProductPromotion
            {
                PromotionCriteria = promotionCriteria,
                Price = price
            });
        }

        [Given(@"the cart contains '(.*)' of product '(.*)'")]
        public void GivenTheCartContainsOfProduct(int quantity, string sku)
        {
            _promotionEngineContext.Cart.AddItem(new CartItem(GetProduct(sku), quantity));
        }

        [When(@"the customer checks out")]
        public void WhenTheCustomerChecksOut()
        {
            _promotionEngineContext.Checkout = new Checkout(_promotionEngineContext.PromotionEngine);
        }

        [Then(@"the calculated total is '(.*)'")]
        public void ThenTheCalculatedTotalIs(decimal calculatedTotal)
        {
            _promotionEngineContext.Checkout.TotalAfterDiscount(_promotionEngineContext.Cart).Should().Be(calculatedTotal);
        }

        private PromotionCriteria CreatePromotionCriteria(int quantity, string sku)
        {
            return new PromotionCriteria
            {
                Product = GetProduct(sku),
                Quantity = quantity
            };
        }

        private Product GetProduct(string sku)
            => _promotionEngineContext.Products.Single(p => p.Sku == sku);
    }
}
