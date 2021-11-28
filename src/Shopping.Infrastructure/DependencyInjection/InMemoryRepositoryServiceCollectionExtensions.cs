using Microsoft.Extensions.DependencyInjection;
using Shopping.Domain.Contracts;
using Shopping.Infrastructure.Persistence;

namespace Shopping.Infrastructure.DependencyInjection
{
    public static class InMemoryRepositoryServiceCollectionExtension
    {
        public static ServiceCollection AddInMemoryRepositories(this ServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IProductRepository, InMemoryProducts>();
            serviceCollection.AddSingleton<IPromotionRepository, InMemoryPromotions>();
            return serviceCollection;
        }
    }
}
