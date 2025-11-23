using BetterCodePaulChallange.ConsoleApp.Application.Orquestration.Interfaces;
using BetterCodePaulChallange.ConsoleApp.Domain.Contracts.Repository;
using BetterCodePaulChallange.ConsoleApp.Domain.Entities;

namespace BetterCodePaulChallange.ConsoleApp.Application.Orquestration
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherRepository _weatherRepository;

        public WeatherService(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }
        public List<WeatherData> GetWeatherData()
        {
            var weatherData = _weatherRepository.GetWheaterDatas();

            return weatherData;
        }
    }
}
