//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;

//namespace BetterCodePaulChallange.ConsoleApp.Configuration
//{
//    public class Startup
//    {
//        public static IHost CreateHost()
//        {
//            var host = Host.CreateDefaultBuilder()
//                .ConfigureAppConfiguration((ctx, cfg) => 
//                {
//                    cfg.SetBasePath(AppContext.BaseDirectory);
//                    cfg.AddJsonFile(Path.Combine("Configuration", "appsettings.json"), optional: true, reloadOnChange: true);
//                    cfg.AddJsonFile(Path.Combine("Configuration",$"appsettings.{ctx.HostingEnvironment.EnvironmentName}.json"), optional: true, reloadOnChange: true);
                    
//                    cfg.AddEnvironmentVariables();
//                })
//                .ConfigureServices((ctx, services) =>
//                {
//                    services.Configure<AppConfig>(options =>
//                    {
//                        ctx.Configuration.Bind(options);
//                        //SingleTon IWeatherRepositoty e WeatherRepositoty
//                    });
//                })
//                .Build();

//            return host;
//        }
//    }
//}
