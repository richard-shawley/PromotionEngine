using Microsoft.Extensions.DependencyInjection;
using Shopping.Application.Data;
using Shopping.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
