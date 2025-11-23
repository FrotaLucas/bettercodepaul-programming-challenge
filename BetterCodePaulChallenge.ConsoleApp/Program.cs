using BetterCodePaulChallenge.ConsoleApp.Application.Orquestration.Interfaces;
using BetterCodePaulChallenge.ConsoleApp.Configuration;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    public static void Main(string[] args)
    {
        var host = Startup.CreateHost();
        var weatherService = host.Services.GetRequiredService<IWeatherService>();

        string greeting = DateTime.Now.Hour < 12
            ? "Good morning"
            : DateTime.Now.Hour < 18
                ? "Good afternoon"
                : "Good evening";

        Console.WriteLine($"\n=== {greeting}, welcome to the Weather App ===\n");

        bool showMenu = true;

        while (showMenu)
        {
            Console.WriteLine("Choose an option:\n");
            Console.WriteLine(" 1 - Day with the smallest temperature spread");
            Console.WriteLine(" 2 - Lowest historical temperature");
            Console.WriteLine(" 0 - Exit");
            Console.Write("\nOption: ");

            string? commandLine = Console.ReadLine();

            switch (commandLine)
            {
                case "1":
                    var op1 = weatherService.GetSmallestSpread();
                    Console.WriteLine($"\nThe day with the smallest temperature spread is: {op1.Day}\n");
                    break;

                case "2":
                    Console.WriteLine("\nLowest temperature feature is not implemented yet.\n");
                    break;

                case "0":
                    showMenu = false;
                    Console.WriteLine("\nExiting... Goodbye!\n");
                    break;

                default:
                    Console.WriteLine("\nInvalid option. Try again.\n");
                    break;
            }
        }
    }
}
