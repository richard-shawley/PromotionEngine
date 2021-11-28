using Shopping.Domain.Contracts;
using Shopping.Domain.Entities;

namespace Shopping.Application.Data
{
    public class SeedData
    {
        private IProductService _productService;
        private IPromotionService _promotionService;

        public SeedData(IProductService productService, IPromotionService promotionService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _promotionService = promotionService ?? throw new ArgumentNullException(nameof(promotionService));
        }

        public void SeedProducts()
        {
            SeedProduct("A", 50.0M);
            SeedProduct("B", 30.0M);
            SeedProduct("C", 20.0M);
            SeedProduct("D", 15.0M);
        }

        private void SeedProduct(string sku, decimal price)
        {
            _productService.AddProduct(new Product() { Sku = sku, Price = price });
            Console.WriteLine($"Seeded product {sku} at price {price}");
        }

        public void SeedPromotions()
        {
            SeedMultiBuyPromotion(3, "A", 130.0M);
            SeedMultiBuyPromotion(2, "B", 45.0M);
            SeedBundlePromotion(new string[] { "C", "D" }, 30.0M);
        }

        private void SeedMultiBuyPromotion(int quantity, string sku, decimal price)
        {
            var promotionCriteria = CreatePromotionCriteria(quantity, sku);

            _promotionService.AddMultiProductPromotion(
                new MultiProductPromotion
                {
                    PromotionCriteria = new List<PromotionCriteria> {
                        promotionCriteria
                    },
                    Price = price
                });

            Console.WriteLine($"Seeded promotion for {quantity} of {sku} at price {price}");
        }

        private void SeedBundlePromotion(string[] skus, decimal price)
        {
            var promotionCriteria = new List<PromotionCriteria>();

            foreach (var sku in skus)
            {
                promotionCriteria.Add(CreatePromotionCriteria(1, sku));
            }

            _promotionService.AddMultiProductPromotion(
                new MultiProductPromotion
                {
                    PromotionCriteria = promotionCriteria,
                    Price = price
                });

            Console.WriteLine($"Seeded promotion for {String.Join(" and ", skus)} at price {price}");
        }

        private PromotionCriteria CreatePromotionCriteria(int quantity, string sku)
        {
            return new PromotionCriteria
            {
                Product = _productService.GetProduct(sku),
                Quantity = quantity
            };
        }
    }
}
