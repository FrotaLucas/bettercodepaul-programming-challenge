using BetterCodePaulChallange.Domain.Entities;

namespace BetterCodePaulChallange.Domain.Contracts.Repository
{
    public interface IWeatherRepository
    {
        public List<WeatherData> GetWheaterDatas();
    }
}
