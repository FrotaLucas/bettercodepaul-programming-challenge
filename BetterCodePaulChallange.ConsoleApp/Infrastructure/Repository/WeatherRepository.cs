using BetterCodePaulChallange.ConsoleApp.Infrastructure.DataProvider;
using BetterCodePaulChallange.ConsoleApp.Domain.Entities;
using BetterCodePaulChallange.ConsoleApp.Domain.Contracts.Repository;

namespace BetterCodePaulChallange.ConsoleApp.Infrastructure.Repository
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
