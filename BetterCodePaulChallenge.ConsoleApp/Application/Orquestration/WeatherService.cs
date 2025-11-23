using BetterCodePaulChallenge.ConsoleApp.Application.Model;
using BetterCodePaulChallenge.ConsoleApp.Application.Orquestration.Interfaces;
using BetterCodePaulChallenge.ConsoleApp.Domain.Contracts.Repository;

namespace BetterCodePaulChallenge.ConsoleApp.Application.Orquestration
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherRepository _weatherRepository;

        public WeatherService(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }

        public WeatherDataResult GetSmallestSpread()
        {
            var weatherData = _weatherRepository.GetWheaterData();

            if (weatherData == null || weatherData.Count == 0)
                return null;

            WeatherDataResult? response = null;

            foreach (var data in weatherData)
            {
                var amplitude = data.MxT - data.MnT;

                if (response == null || amplitude < response.Amplitude)
                {
                    response = new WeatherDataResult
                    {
                        Day = data.Day,
                        MxT = data.MxT,
                        MnT = data.MnT,
                        Amplitude = amplitude,
                        AvT = data.AvT
                    };
                }
            }

            return response!;
        }
    }
}
