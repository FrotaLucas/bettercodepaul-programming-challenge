using BetterCodePaulChallenge.ConsoleApp.Infrastructure.DataProvider;
using BetterCodePaulChallenge.ConsoleApp.Domain.Entities;
using BetterCodePaulChallenge.ConsoleApp.Domain.Contracts.Repository;

namespace BetterCodePaulChallenge.ConsoleApp.Infrastructure.Repository
{
    public class CountryRepository (FilesReader fr) : ICountryRepository
    {
        public List<CountryData> GetCountryData()
        {
            List<CountryData> data = new List<CountryData>();

            data = fr.ReadCountryCsv();

            if (data == null || data.Count == 0)
                return null;

            data = fr.ReadCountryCsv();

            return data;
        }
    }
}
