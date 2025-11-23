using BetterCodePaulChallange.ConsoleApp.Application.Model;

namespace BetterCodePaulChallange.ConsoleApp.Application.Orquestration.Interfaces
{
    public interface IWeatherService
    {
        WeatherDataResult GetWeatherData();
    }
}
