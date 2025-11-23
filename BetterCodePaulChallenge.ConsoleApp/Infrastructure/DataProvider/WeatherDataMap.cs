using BetterCodePaulChallenge.ConsoleApp.Domain.Entities;
using CsvHelper.Configuration;

namespace BetterCodePaulChallenge.ConsoleApp.Infrastructure.DataProvider
{
    public class WeatherDataMap : ClassMap<WeatherData>
    {
        public WeatherDataMap()
        {
            Map(m => m.Day).Name("Day");
            Map(m => m.MxT).Name("MxT");
            Map(m => m.MnT).Name("MnT");
            Map(m => m.AvT).Name("AvT");
            Map(m => m.AvDP).Name("AvDP");
            Map(m => m.OneHrPTPcpn).Name("1HrP TPcpn");
            Map(m => m.PDir).Name("PDir");
            Map(m => m.AvSp).Name("AvSp");
            Map(m => m.Dir).Name("Dir");
            Map(m => m.MxS).Name("MxS");
            Map(m => m.SkyC).Name("SkyC");
            Map(m => m.MxR).Name("MxR");
            Map(m => m.Mn).Name("Mn");
            Map(m => m.RAvSLP).Name("R AvSLP");
        }
    }
}
