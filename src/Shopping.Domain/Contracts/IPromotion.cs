using Shopping.Domain.Entities;
using Shopping.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Domain.Contracts
{
    public interface IPromotion
    {
        List<PromotionCriteria> PromotionCriteria { get; }
        bool IsValid(IEnumerable<CartItem> cartItems);
        decimal GetDiscountOnCartItems(IEnumerable<CartItem> cartItems);
    }
}
