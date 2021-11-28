using Shopping.Domain.Contracts;
using Shopping.Domain.Entities;

namespace Shopping.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public IEnumerable<Product> GetProducts()
            => _productRepository.GetAll().OrderBy(p => p.Sku);

        public Product GetProduct(string sku)
            => _productRepository.Query().Single(p => p.Sku == sku);

        public void AddProduct(Product product)
            => _productRepository.Add(product);
    }
}
