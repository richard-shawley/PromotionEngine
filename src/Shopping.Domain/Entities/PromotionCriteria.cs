using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Domain.Entities
{
    public record PromotionCriteria
    {
        public Product Product { get; init; } = default!;
        public int Quantity { get; set; }
    }
}
