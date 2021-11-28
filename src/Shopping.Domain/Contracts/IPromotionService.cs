using Shopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Domain.Contracts
{
    public interface IPromotionService
    {
        IEnumerable<IPromotion> GetPromotions();
        IPromotion? FindPromotion(string sku);
        void AddMultiProductPromotion(MultiProductPromotion promotion);
    }
}
