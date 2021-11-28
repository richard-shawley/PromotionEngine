using Shopping.Domain.Contracts;
using Shopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Infrastructure.Persistence
{
    public class InMemoryProducts : InMemoryRepository<Product>, IProductRepository
    {
    }
}
