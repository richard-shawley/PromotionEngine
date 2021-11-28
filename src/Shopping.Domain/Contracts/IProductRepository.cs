using Shopping.Domain.Entities;

namespace Shopping.Domain.Contracts
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        IQueryable<Product> Query();
        void Add(Product product);
    }
}
