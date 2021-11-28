using Shopping.Domain.Entities;

namespace Shopping.Domain.Contracts
{
    public interface IPromotionService
    {
        IEnumerable<IPromotion> GetPromotions();
        IPromotion? FindPromotion(string sku);
        void AddMultiProductPromotion(MultiProductPromotion promotion);
    }
}
