using Microsoft.Extensions.DependencyInjection;
using Shopping.Domain.Contracts;
using Shopping.Domain.Models;
using Shopping.Domain.Services;

namespace Shopping.Domain.DependencyInjection
{
    public static class ShoppingServiceCollectionExtensions
    {
        public static ServiceCollection AddShopping(this ServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IProductService, ProductService>();
            serviceCollection.AddTransient<IPromotionService, PromotionService>();
            serviceCollection.AddTransient<PromotionEngine>();
            serviceCollection.AddTransient<Cart>();
            serviceCollection.AddTransient<Checkout>();
            return serviceCollection;
        }
    }
}
