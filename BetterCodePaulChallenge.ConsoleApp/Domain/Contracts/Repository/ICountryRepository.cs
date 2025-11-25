
using BetterCodePaulChallenge.ConsoleApp.Domain.Entities;

namespace BetterCodePaulChallenge.ConsoleApp.Domain.Contracts.Repository
{
    public interface ICountryRepository
    {
        public List<CountryData> GetCountryData();
    }
}
