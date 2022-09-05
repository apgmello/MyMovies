using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyMovies.Repositories.Api.Extensions;
using MyMovies.Services;

namespace MyMovie.ConsoleApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true)
                .Build();

            var serviceCollection = new ServiceCollection();



            serviceCollection
                .AddSingleton(configuration)
                .AddServices()
                .AddApiRepository()
                .AddSingleton<Program>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var program = serviceProvider?.GetService<Program>();

            program?.Execute();
        }

        private readonly MenuService menuService;
        
        public Program(MenuService menuService)
        {
            this.menuService = menuService;
        }
        public void Execute()
        {
           menuService.InitializeMenu();
        }

    }
}