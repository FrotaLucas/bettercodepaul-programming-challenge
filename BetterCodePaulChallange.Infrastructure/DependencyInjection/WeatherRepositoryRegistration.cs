using BetterCodePaulChallange.Domain.Contracts.Repository;
using BetterCodePaulChallange.Infrastructure.DataProvider;
using BetterCodePaulChallange.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace BetterCodePaulChallange.Infrastructure.DependencyInjection
{
    public static class WeatherRepositoryRegistration
    {
        public static IServiceCollection AddWeatherRepository(this IServiceCollection services)
        {
            // Repositórios
            services.AddSingleton<IWeatherRepository, WeatherRepository>();

            // Providers
            services.AddSingleton<FilesReader>();

            return services;
        }
    }
}
