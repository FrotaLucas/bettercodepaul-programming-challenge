
using BetterCodePaulChallange.Config.Configuration;
using BetterCodePaulChallange.Infrastructure.DependencyInjection;
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
                    //cfg.AddJsonFile(Path.Combine("BetterCodePaulChallange.Config/Configuration", "appsettings.json"), optional: true, reloadOnChange: true);
                    //cfg.AddJsonFile(Path.Combine("BetterCodePaulChallange.Config/Configuration", $"appsettings.{ctx.HostingEnvironment.EnvironmentName}.json"), optional: true, reloadOnChange: true);
                    cfg.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                    cfg.AddJsonFile($"appsettings.{ctx.HostingEnvironment.EnvironmentName}.json", optional: true);

                    cfg.AddEnvironmentVariables();
                })
                .ConfigureServices((ctx, services) =>
                {
                    //v1
                    services.Configure<AppConfig>(options =>
                    {
                        ctx.Configuration.Bind(options);


                    });

                    //v2
                    //services.Configure<AppConfig>(
                    //ctx.Configuration.GetSection("AppConfig"));

                    //v3
                    //services.Configure<AppConfig>(ctx.Configuration);


                    // Add Singletonn WeatherRepository
                    services.AddWeatherRepository();

                }).Build();


    }
}