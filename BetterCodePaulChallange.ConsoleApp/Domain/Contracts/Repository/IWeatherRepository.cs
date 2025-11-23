
using BetterCodePaulChallange.ConsoleApp.Domain.Entities;

namespace BetterCodePaulChallange.ConsoleApp.Domain.Contracts.Repository
{
    public interface IWeatherRepository
    {
        public List<WeatherData> GetWheaterDatas();
    }
}
