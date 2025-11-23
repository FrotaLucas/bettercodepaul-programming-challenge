using BetterCodePaulChallenge.ConsoleApp.Infrastructure.DataProvider;
using BetterCodePaulChallenge.ConsoleApp.Domain.Entities;
using BetterCodePaulChallenge.ConsoleApp.Domain.Contracts.Repository;

namespace BetterCodePaulChallenge.ConsoleApp.Infrastructure.Repository
{
    public class WeatherRepository (FilesReader fr) : IWeatherRepository
    {
        public List<WeatherData> GetWheaterData()
        {
            List<WeatherData> data = new List<WeatherData>();

            data = fr.ReadWeatherCsv();

            if (data == null || data.Count == 0)
                return null;

            data = fr.ReadWeatherCsv();

            return data;
        }
    }
}
