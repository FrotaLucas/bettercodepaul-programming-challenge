using BetterCodePaulChallenge.ConsoleApp.Application.Model;

namespace BetterCodePaulChallenge.ConsoleApp.Application.Orquestration.Interfaces
{
    public interface IWeatherService
    {
        WeatherDataResult GetSmallestSpread();
    }
}
