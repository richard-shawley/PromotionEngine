using Microsoft.Extensions.DependencyInjection;
using Shopping.Application.Data;
using Shopping.Application.Interface;

namespace Shopping.Application.DependencyInjection
{
    public static class ShoppingConsoleServiceCollectionExtensions
    {
        public static ServiceCollection AddShoppingConsole(this ServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<SeedData>();
            serviceCollection.AddTransient<ShoppingConsole>();
            return serviceCollection;
        }
    }
}
