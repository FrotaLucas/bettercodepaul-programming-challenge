using BetterCodePaulChallenge.ConsoleApp.Application.Orquestration.Interfaces;
using BetterCodePaulChallenge.ConsoleApp.Configuration;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    public static void Main(string[] args)
    {
        var host = Startup.CreateHost();
        var countryService = host.Services.GetRequiredService<ICountryService>();

        string greeting = DateTime.Now.Hour < 12
            ? "Good morning"
            : DateTime.Now.Hour < 18
                ? "Good afternoon"
                : "Good evening";

        Console.WriteLine($"\n=== {greeting}, welcome to the Console App ===\n");

        bool showMenu = true;

        while (showMenu)
        {
            Console.WriteLine("Choose an option:\n");
            Console.WriteLine(" 1 - Country with the highest population density");
            Console.WriteLine(" 2 - Smallest population ");
            Console.WriteLine(" 0 - Exit");
            Console.Write("\nOption: ");

            string? commandLine = Console.ReadLine();

            switch (commandLine)
            {
                case "1":
                    var op1 = countryService.GethighestDensity();
                    Console.WriteLine($"\nThe country with the highest population is: {op1.Name}\n");
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
