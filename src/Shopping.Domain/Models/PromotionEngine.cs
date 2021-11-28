using Shopping.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }
    }
}
