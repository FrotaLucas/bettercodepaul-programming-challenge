using System.Globalization;
using System.Text.Json;
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
            if (!File.Exists(_appConfig.CsvPath.Countries))
            {
                Log.Warn($"[WARN] File not found. Path: {_appConfig.CsvPath.Countries}");
                throw new FileNotFoundException("Countrie CSV not found.", _appConfig.CsvPath.Countries);
            }
        }

        public List<CountryData> ReadWeatherCsv()
        {
            CheckIfFileExist();
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                HasHeaderRecord = true,
                TrimOptions = TrimOptions.Trim,
                BadDataFound = (ex) =>
                {
                    Log.Warn($"Bad data found on row {ex.Context.Parser.Row}: {ex.RawRecord}");
                }
            };

            var reader = new StreamReader(_appConfig.CsvPath.Countries);
            var csv = new CsvReader(reader, config);
            csv.Context.RegisterClassMap<CountryDataMap>();

            var result = csv.GetRecords<CountryData>().ToList();

            return result;
        }


        public List<CountryData> ReadCountriesJson()
        {
            CheckIfFileExist();

            var json = File.ReadAllText(_appConfig.DataFilesJson.Countries);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<List<CountryData>>(json, options)
                   ?? new List<CountryData>();
        }

    }
}
