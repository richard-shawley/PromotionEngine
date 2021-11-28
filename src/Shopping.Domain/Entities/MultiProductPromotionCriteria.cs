using Shopping.Domain.Contracts;
using Shopping.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Domain.Entities
{
    public record MultiProductPromotion : IPromotion
    {
        public List<PromotionCriteria> PromotionCriteria { get; init; } = new List<PromotionCriteria>();

        public bool IsValid(IEnumerable<CartItem> cartItems)
        {
            throw new NotImplementedException();
        }

        public decimal GetDiscountOnCartItems(IEnumerable<CartItem> cartItems)
        {
            throw new NotImplementedException();
        }

        public decimal Price { get; init; }
    }
}
