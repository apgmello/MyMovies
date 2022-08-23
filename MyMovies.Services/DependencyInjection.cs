using Microsoft.Extensions.DependencyInjection;

namespace MyMovies.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<MenuService>();
            return services;
        }
    }
}
