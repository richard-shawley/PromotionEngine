using Shopping.Domain.Entities;

namespace Shopping.Domain.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(string sku);
        void AddProduct(Product product);
    }
}
