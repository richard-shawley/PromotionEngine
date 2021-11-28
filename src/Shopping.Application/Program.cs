using Microsoft.Extensions.DependencyInjection;
using Shopping.Application.DependencyInjection;
using Shopping.Domain.DependencyInjection;
using Shopping.Infrastructure.DependencyInjection;
using Shopping.Application.Data;

namespace Shopping.Application
{
    class Program
    {
        private static ServiceProvider? _serviceProvider;
        static void Main(string[] args)
        {
            _serviceProvider = BuildServiceProvider();

            var seedData = _serviceProvider!.GetService<SeedData>() ?? throw new InvalidOperationException();
            Console.WriteLine("--------------- SEEDING DATA START ---------------");
            seedData.SeedProducts();
            seedData.SeedPromotions();
            Console.WriteLine("--------------- SEEDING DATA FINISHED ---------------");
        }

        static ServiceProvider BuildServiceProvider()
            => new ServiceCollection()
            .AddInMemoryRepositories()
            .AddShopping()
            .AddShoppingConsole()
            .BuildServiceProvider();

    }
}