using Shopping.Domain.Contracts;
using Shopping.Domain.Entities;

namespace Shopping.Domain.Services
{
    public class PromotionService : IPromotionService
    {
        private readonly IPromotionRepository _promotionRepository;

        public PromotionService(IPromotionRepository promotionRepository)
        {
            _promotionRepository = promotionRepository ?? throw new ArgumentNullException(nameof(promotionRepository));
        }

        public IEnumerable<IPromotion> GetPromotions()
            => _promotionRepository.GetAll();

        public IPromotion? FindPromotion(string sku)
            => _promotionRepository.Query().FirstOrDefault(p => p.PromotionCriteria.Any(pC => pC.Product.Sku == sku));

        public void AddMultiProductPromotion(MultiProductPromotion promotion)
            => _promotionRepository.Add(promotion);
    }
}
