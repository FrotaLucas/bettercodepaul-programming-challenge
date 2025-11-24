namespace BetterCodePaulChallenge.ConsoleApp.Domain.Entities
{
    public class CountryData
    {
        public string Name { get; set; } = default!;
        public string Capital { get; set; } = default!;
        public string Accession { get; set; } = default!;
        public double Population { get; set; } = default!;
        public int AreaKm2 { get; set; } = default!;
        public int GDPUsdM { get; set; } = default!;
        public double HDI { get; set; } = default!;
        public int MEPs { get; set; } = default!;
    }
}
