using BetterCodePaulChallenge.ConsoleApp.Domain.Entities;
using CsvHelper.Configuration;

namespace BetterCodePaulChallenge.ConsoleApp.Infrastructure.DataProvider
{
    public class CountryDataMap : ClassMap<CountryData>
    {
        public CountryDataMap()
        {
            Map(m => m.Name).Name("Name");
            Map(m => m.Capital).Name("Capital");
            Map(m => m.Accession).Name("Accession");
            Map(m => m.Population).Name("Population").TypeConverter<PopulationConverter>();
            Map(m => m.AreaKm2).Name("Area (km²)");
            Map(m => m.GDPUsdM).Name("GDP (US$ M)");
            Map(m => m.HDI).Name("HDI");
            Map(m => m.MEPs).Name("MEPs");
        }
    }
}
