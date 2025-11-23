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
        public WeatherDataResult GetWeatherData()
        {
            var weatherData = _weatherRepository.GetWheaterData();

            //ADD verificacao quando weatherData for nulo ????
            //if weatherData == nulo 

            var result = new WeatherDataResult();
            result.Amplitude = 0;

            foreach(var data in weatherData)
            {
                var amplitude = data.MxT - data.MnT;

                if (result.Amplitude < amplitude)
                {
                    result = new WeatherDataResult
                    {
                        Day = data.Day,
                        Amplitude = amplitude,
                        MnT = data.MnT,
                        MxT = data.MnT,
                        AvT = data.MnT,
                    };
                }
            }
            


            return result; ;
        }
    }
}
