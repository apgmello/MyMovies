using Microsoft.Extensions.DependencyInjection;

namespace MyMovies.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMenuService(this IServiceCollection services)
        {
            services.AddScoped<MenuService>();
            return services;
        }

        public static IServiceCollection AddLoginService(this IServiceCollection services)
        {
            services.AddScoped<LoginService>();
            return services;
        }
    }
}
