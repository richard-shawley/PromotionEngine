using Shopping.Domain.Entities;

namespace Shopping.Domain.Contracts
{
    public interface IPromotionRepository
    {
        IEnumerable<MultiProductPromotion> GetAll();
        IQueryable<MultiProductPromotion> Query();
        void Add(MultiProductPromotion promotion);
    }
}
