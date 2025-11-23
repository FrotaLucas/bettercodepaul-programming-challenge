namespace BetterCodePaulChallange.ConsoleApp.Application.Model
{
    public class WeatherDataResult
    {
        public int Day { get; set; } = default!;
        public double MxT { get; set; } = default!;
        public double MnT { get; set; } = default!;
        public double Amplitude { get; set; } = default!;   
        public double AvT {  get; set; }  = default!;
    }
}
