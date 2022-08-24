using ConsoleTables;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyMovies.Entities;
using MyMovies.Repositories.Api.Extensions;
using MyMovies.Repositories.Interfaces;
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

            var conteudoBaldinho = new ServiceCollection();

            conteudoBaldinho
                .AddSingleton(configuration)
                .AddServices()
                .AddApiRepository()
                .AddSingleton<Program>();

            var baldinho = conteudoBaldinho.BuildServiceProvider();

            var program = baldinho?.GetService<Program>();

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