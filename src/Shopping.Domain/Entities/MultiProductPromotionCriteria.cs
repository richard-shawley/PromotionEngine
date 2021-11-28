using Shopping.Domain.Contracts;
using Shopping.Domain.Models;

namespace Shopping.Domain.Entities
{
    public record MultiProductPromotion : IPromotion
    {
        public List<PromotionCriteria> PromotionCriteria { get; init; } = new List<PromotionCriteria>();

        public bool IsValid(IEnumerable<CartItem> cartItems)
            => PromotionCriteria.All(pC => cartItems.Any(cI => cI.Product == pC.Product && cI.Quantity >= pC.Quantity));

        public decimal GetDiscountOnCartItems(IEnumerable<CartItem> cartItems)
            => TimesApplies(cartItems) * PromotionProductsDiscount;

        public decimal Price { get; init; }

        private int TimesApplies(IEnumerable<CartItem> cartItems)
            => PromotionCriteria.Select(pC => cartItems.Single(cI => pC.Product == cI.Product).Quantity / pC.Quantity).Min();

        private decimal PromotionProductsFullValue
            => PromotionCriteria.Sum(p => p.Product.Price * p.Quantity);

        private decimal PromotionProductsDiscount
            => PromotionProductsFullValue - Price;
    }
}
