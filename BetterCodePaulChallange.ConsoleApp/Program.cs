using BetterCodePaulChallange.ConsoleApp.Application.Orquestration.Interfaces;
using BetterCodePaulChallange.ConsoleApp.Configuration;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    private static void Main(string[] args)
    {
        var host = Startup.CreateHost();
        var weatherService = host.Services.GetRequiredService<IWeatherService>();

        var data = weatherService.GetWeatherData();


        Console.WriteLine(data);
    }
}