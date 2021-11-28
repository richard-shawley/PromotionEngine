using Moq;
using Shopping.Domain.Contracts;
using Shopping.Domain.Entities;
using Shopping.Domain.Models;

namespace Shopping.Specs.Context
{
    public class PromotionEngineContext
    {
        private readonly Mock<IPromotionService> _promotionService;
        public PromotionEngineContext()
        {
            _promotionService = new Mock<IPromotionService>();
        }

        private PromotionEngine GetPromotionEngine()
        {
            _promotionService.Setup(o => o.GetPromotions()).Returns(() => Promotions);
            return new PromotionEngine(_promotionService.Object);
        }

        public List<MultiProductPromotion> Promotions { get; set; } = new List<MultiProductPromotion>();
        public PromotionEngine PromotionEngine => GetPromotionEngine();
        public Cart Cart { get; set; } = new Cart();
        public List<Product> Products { get; set; } = new List<Product>();
        public Checkout Checkout { get; set; }
    }
}
