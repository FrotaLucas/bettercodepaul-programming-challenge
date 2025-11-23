using BetterCodePaulChallange.ConsoleApp.Application.Model;
using BetterCodePaulChallange.ConsoleApp.Application.Orquestration.Interfaces;
using BetterCodePaulChallange.ConsoleApp.Domain.Contracts.Repository;

namespace BetterCodePaulChallange.ConsoleApp.Application.Orquestration
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherRepository _weatherRepository;

        public WeatherService(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }

        //PODE SER QUE TENHA MAIS DE DIA COM MENOR TEMPERATURA. PENSAR EM LISTAAAAAAAA!
        public WeatherDataResult GetSmallestSpread()
        {
            var weatherData = _weatherRepository.GetWheaterData();

            if (weatherData == null || weatherData.Count == 0)
                return null; // ou lance exceção

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
