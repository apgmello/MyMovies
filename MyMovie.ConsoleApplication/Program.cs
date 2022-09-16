using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyMovies.Entities;
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

            var loginServiceCollection = new ServiceCollection();

            loginServiceCollection
                .AddSingleton(configuration)
                .AddLoginService()
                .AddLoginApiRepository();

            var serviceProvider = loginServiceCollection.BuildServiceProvider();
            var loginService = serviceProvider?.GetService<LoginService>();

            var authenticationToken = loginService?.Login();

            //-------------------------------------------------------------

            var menuServiceCollection = new ServiceCollection();
            
            menuServiceCollection
                .AddSingleton(configuration)
                .AddSingleton(authenticationToken)
                .AddMenuService()
                .AddMoviesApiRepositories();

            serviceProvider = menuServiceCollection.BuildServiceProvider();

            var menuService = serviceProvider?.GetService<MenuService>();
            menuService?.InitializeMenu();
        }
    }
}