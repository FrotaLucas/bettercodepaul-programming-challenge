using BetterCodePaulChallenge.ConsoleApp.Infrastructure.DataProvider;
using BetterCodePaulChallenge.ConsoleApp.Domain.Entities;
using BetterCodePaulChallenge.ConsoleApp.Domain.Contracts.Repository;

namespace BetterCodePaulChallenge.ConsoleApp.Infrastructure.Repository
{
    public class CountryRepository (FilesReader fr) : ICountryRepository
    {
        public List<CountryData> GetWheaterData()
        {
            List<CountryData> data = new List<CountryData>();

            data = fr.ReadWeatherCsv();

            if (data == null || data.Count == 0)
                return null;

            data = fr.ReadWeatherCsv();

            return data;
        }
    }
}
