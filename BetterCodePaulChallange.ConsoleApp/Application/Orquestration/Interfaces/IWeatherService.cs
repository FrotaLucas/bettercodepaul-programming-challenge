using BetterCodePaulChallange.ConsoleApp.Domain.Entities;

namespace BetterCodePaulChallange.ConsoleApp.Application.Orquestration.Interfaces
{
    public interface IWeatherService
    {
        List<WeatherData> GetWeatherData();
    }
}
