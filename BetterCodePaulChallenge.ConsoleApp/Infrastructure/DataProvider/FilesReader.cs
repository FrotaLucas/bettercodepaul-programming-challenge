using System.Globalization;
using BetterCodePaulChallenge.ConsoleApp.Domain.Entities;
using CsvHelper;
using CsvHelper.Configuration;
using log4net;
using Microsoft.Extensions.Options;

namespace BetterCodePaulChallenge.ConsoleApp.Infrastructure.DataProvider
{
    public class FilesReader(IOptions<AppConfig> appConfig)
    {

        private readonly AppConfig _appConfig = appConfig.Value;
        private readonly ILog Log = LogManager.GetLogger(typeof(FilesReader));

        private void CheckIfFileExist()
        {
            if (!File.Exists(_appConfig.CsvPath.Weather))
            {
                Log.Warn($"[WARN] File not found. Path: {_appConfig.CsvPath.Weather}");
                throw new FileNotFoundException("Weather CSV not found.", _appConfig.CsvPath.Weather);
            }
        }

        public virtual List<WeatherData> ReadWeatherCsv()
        {
            CheckIfFileExist();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                HasHeaderRecord = true,
                TrimOptions = TrimOptions.Trim,
                BadDataFound = (ex) =>
                {
                    Log.Warn($"Bad data found on row {ex.Context.Parser.Row}: {ex.RawRecord}");
                }
            };

            var reader = new StreamReader(_appConfig.CsvPath.Weather);
            var csv = new CsvReader(reader, config);
            csv.Context.RegisterClassMap<WeatherDataMap>();

            var result = csv.GetRecords<WeatherData>().ToList();

            return result;
        }
    }
}
