using BetterCodePaulChallange.ConsoleApp.Application.Configuration;
using BetterCodePaulChallange.ConsoleApp.Application.Orquestration;
using BetterCodePaulChallange.ConsoleApp.Application.Orquestration.Interfaces;
using BetterCodePaulChallange.ConsoleApp.Domain.Contracts.Repository;
using BetterCodePaulChallange.ConsoleApp.Infrastructure.DataProvider;
using BetterCodePaulChallange.ConsoleApp.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

internal class Program
{
    private static void Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((ctx, cfg) =>
                {
                    cfg.SetBasePath(AppContext.BaseDirectory);
                    cfg.AddJsonFile(Path.Combine("Application", "appsettings.json"), optional: true, reloadOnChange: true);
                    cfg.AddJsonFile(Path.Combine("Application", $"appsettings.{ctx.HostingEnvironment.EnvironmentName}.json"), optional: true, reloadOnChange: true);
                    //cfg.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                    //cfg.AddJsonFile($"appsettings.{ctx.HostingEnvironment.EnvironmentName}.json", optional: true);

                    cfg.AddEnvironmentVariables();
                })
                .ConfigureServices((ctx, services) =>
                {
                    //v1
                    services.Configure<AppConfig>(options =>
                    {
                        ctx.Configuration.Bind(options);


                    });

                    services.AddSingleton<FilesReader>();
                    services.AddSingleton<IWeatherRepository, WeatherRepository>();
                    services.AddSingleton<IWeatherService, WeatherService>();

                }).Build();


                var weatherService = host.Services.GetRequiredService<IWeatherService>();   

                var data = weatherService.GetWeatherData();
        Console.WriteLine(data);
    }
}