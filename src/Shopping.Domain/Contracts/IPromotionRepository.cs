using Shopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Domain.Contracts
{
    public interface IPromotionRepository
    {
        IEnumerable<MultiProductPromotion> GetAll();
        IQueryable<MultiProductPromotion> Query();
        void Add(MultiProductPromotion promotion);
    }
}
