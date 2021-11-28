﻿using Shopping.Domain.Contracts;
using Shopping.Domain.Entities;

namespace Shopping.Infrastructure.Persistence
{
    public class InMemoryPromotions : InMemoryRepository<MultiProductPromotion>, IPromotionRepository
    {
    }
}
