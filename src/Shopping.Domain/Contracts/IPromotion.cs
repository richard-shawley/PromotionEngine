using Shopping.Domain.Entities;
using Shopping.Domain.Models;

namespace Shopping.Domain.Contracts
{
    public interface IPromotion
    {
        List<PromotionCriteria> PromotionCriteria { get; }
        bool IsValid(IEnumerable<CartItem> cartItems);
        decimal GetDiscountOnCartItems(IEnumerable<CartItem> cartItems);
    }
}
