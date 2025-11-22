using BetterCodePaulChallange.Domain.Contracts.Repository;
using BetterCodePaulChallange.Domain.Entities;
using BetterCodePaulChallange.Infrastructure.DataProvider;

namespace BetterCodePaulChallange.Infrastructure.Repository
{
    public class WeatherRepository (FilesReader fr) : IWeatherRepository
    {
        public List<WeatherData> GetWheaterDatas()
        {
            List<WeatherData> data = new List<WeatherData>();

            data = fr.ReadWeatherCsv();

            return data;
        }
    }
}
