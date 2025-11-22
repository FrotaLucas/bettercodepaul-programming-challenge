namespace BetterCodePaulChallange.ConsoleApp.Configuration
{
    public class AppConfig
    {
        public CsvPathConfig CsvPath { get; set; } = new CsvPathConfig();

        public sealed class CsvPathConfig
        {
            public string WeatherPath { get; set; } = default!;
        }
    }
}
