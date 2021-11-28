using Shopping.Domain.Contracts;

namespace Shopping.Domain.Models
{
    public class PromotionEngine
    {
        private IPromotionService _promotionService;
        private readonly List<IPromotion> _promotions;
        public IEnumerable<IPromotion> Promotions => _promotions.AsReadOnly();

        public PromotionEngine(IPromotionService promotionService)
        {
            _promotionService = promotionService;
            _promotions = _promotionService.GetPromotions().ToList();
        }

        public decimal GetDiscount(IEnumerable<CartItem> cartItems)
        {
            if (cartItems == null) throw new ArgumentNullException(nameof(cartItems));
            if (cartItems.Count() == 0) return 0.0M;

            var applicablePromotions = GetApplicablePromtions(cartItems);
            var discount = GetApplicablePromtions(cartItems).Sum(p => p.GetDiscountOnCartItems(cartItems));
            return discount;
        }

        private IEnumerable<IPromotion> GetApplicablePromtions(IEnumerable<CartItem> cartItems)
            => _promotions.Where(p => p.IsValid(cartItems));
    }
}
