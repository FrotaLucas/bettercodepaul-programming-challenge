namespace BetterCodePaulChallenge.ConsoleApp
{
    public class AppConfig
    {
        public CsvPathConfig CsvPath { get; set; } = new CsvPathConfig();

        public JsonPathConfig JsonPath { get; set; } = new JsonPathConfig();

        public sealed class CsvPathConfig
        {
            public string Weather { get; set; } = default!;
            public string Countries { get; set; } = default!;

        }

        public sealed class JsonPathConfig
        {
            public string Countries { get; set; } = default!;
        }
    }
}
