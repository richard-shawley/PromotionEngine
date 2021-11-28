namespace Shopping.Domain.Models
{
    public class Checkout
    {
        private PromotionEngine _promotionEngine;
        public Checkout(PromotionEngine promotionEngine)
        {
            _promotionEngine = promotionEngine ?? throw new ArgumentNullException(nameof(promotionEngine));
        }

        public decimal Discount(Cart cart)
        {
            if (cart == null) throw new ArgumentNullException(nameof(cart));

            return _promotionEngine.GetDiscount(cart.Items);
        }

        public decimal TotalAfterDiscount(Cart cart)
        {
            if (cart == null) throw new ArgumentNullException(nameof(cart));

            return cart.Total - Discount(cart);
        }
    }
}
