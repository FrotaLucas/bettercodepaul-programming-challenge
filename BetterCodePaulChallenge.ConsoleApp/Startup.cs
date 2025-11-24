using BetterCodePaulChallenge.ConsoleApp.Application.Orquestration;
using BetterCodePaulChallenge.ConsoleApp.Application.Orquestration.Interfaces;
using BetterCodePaulChallenge.ConsoleApp.Domain.Contracts.Repository;
using BetterCodePaulChallenge.ConsoleApp.Infrastructure.DataProvider;
using BetterCodePaulChallenge.ConsoleApp.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BetterCodePaulChallenge.ConsoleApp.Configuration
{
    public class Startup
    {
        public static IHost CreateHost()
        {
            var host = Host.CreateDefaultBuilder()
                 .ConfigureAppConfiguration((ctx, cfg) =>
                 {
                     cfg.SetBasePath(AppContext.BaseDirectory);
                     cfg.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                     cfg.AddJsonFile($"appsettings.{ctx.HostingEnvironment.EnvironmentName}.json", optional: true);

                     cfg.AddEnvironmentVariables();
                 })
                 .ConfigureServices((ctx, services) =>
                 {
                     services.Configure<AppConfig>(options =>
                     {
                         ctx.Configuration.Bind(options);
                     });

                     services.AddSingleton<FilesReader>();
                     services.AddSingleton<ICountryRepository, CountryRepository>();
                     services.AddSingleton<ICountryService, CountryService>();

                 }).Build();

            return host;
        }
    }
}
