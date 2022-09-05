using MyMovies.Api.Loggger;

namespace MyMovies.Api.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddEventLogger(this IServiceCollection services)
        {
            services.AddTransient<LogBase, EventLogger>();
            return services;
        }
    }
}
