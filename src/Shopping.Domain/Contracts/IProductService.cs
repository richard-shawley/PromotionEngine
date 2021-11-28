using Shopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Domain.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(string sku);
        void AddProduct(Product product);
    }
}
