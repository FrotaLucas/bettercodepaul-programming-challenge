namespace BetterCodePaulChallenge.ConsoleApp
{
    public class AppConfig
    {
        public CsvPathConfig CsvPath { get; set; } = new CsvPathConfig();

        public sealed class CsvPathConfig
        {
            public string Weather { get; set; } = default!;
            public string Countries { get; set; } = default!;

        }
    }
}
