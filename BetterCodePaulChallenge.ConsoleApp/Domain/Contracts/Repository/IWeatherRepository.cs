
using BetterCodePaulChallenge.ConsoleApp.Domain.Entities;

namespace BetterCodePaulChallenge.ConsoleApp.Domain.Contracts.Repository
{
    public interface IWeatherRepository
    {
        public List<WeatherData> GetWheaterData();
    }
}
