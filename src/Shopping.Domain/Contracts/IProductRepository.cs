using Shopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Domain.Contracts
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        IQueryable<Product> Query();
        void Add(Product product);
    }
}
