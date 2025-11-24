using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System.Globalization;

namespace BetterCodePaulChallenge.ConsoleApp.Infrastructure.DataProvider
{
    public class PopulationConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrWhiteSpace(text))
                return 0;

            text = text.Trim();
            text = text.Replace(".", "");

            text = text.Replace(",", ".");

            if (double.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out double value))
                return value;

            throw new TypeConverterException(this, memberMapData, text, row.Context, $"Cannot convert '{text}' to long.");
        }
    }

}
