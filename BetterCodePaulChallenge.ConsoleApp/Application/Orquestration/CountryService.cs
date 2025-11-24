using BetterCodePaulChallenge.ConsoleApp.Application.Model;
using BetterCodePaulChallenge.ConsoleApp.Application.Orquestration.Interfaces;
using BetterCodePaulChallenge.ConsoleApp.Domain.Contracts.Repository;

namespace BetterCodePaulChallenge.ConsoleApp.Application.Orquestration
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _weatherRepository;

        public CountryService(ICountryRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }


        public CountryDataResult GethighestDensity()
        {
            var countryData = _weatherRepository.GetWheaterData();

            if (countryData == null || countryData.Count == 0)
                return null;

            CountryDataResult? response = null;

            foreach (var data in countryData)
            {
                var density = data.Population / data.AreaKm2;

                if (response == null || density > response.Density)
                {
                    response = new CountryDataResult
                    {
                        Name = data.Name,
                        Population = data.Population,
                        AreaKm2 = data.AreaKm2,
                        Density = density
                    };
                }
            }

            return response!;

        }


    }
}
