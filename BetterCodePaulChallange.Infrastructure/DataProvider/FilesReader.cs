using System.Globalization;
using BetterCodePaulChallange.ConsoleApp.Configuration;
using BetterCodePaulChallange.Domain.Entities;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.Options;

namespace BetterCodePaulChallange.Infrastructure.DataProvider
{
    public class FilesReader(IOptions<AppConfig> appConfig)
    {
        
        private readonly AppConfig _appConfig = appConfig.Value;

        public List<WeatherData> ReadWeatherCsv()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                HasHeaderRecord = true,
                TrimOptions = TrimOptions.Trim,
            };

            var reader = new StreamReader(_appConfig.CsvPath.WeatherPath);
            var csv = new CsvReader(reader, config);

            var result = csv.GetRecords<WeatherData>();

            return [.. result];

        }
    }
}
