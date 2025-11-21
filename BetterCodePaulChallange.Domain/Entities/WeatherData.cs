using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterCodePaulChallange.Domain.Entities
{
    public class WeatherData
    {
        public int Day { get; set; }
        public double MxT { get; set; }
        public double MnT { get; set; }
        public double AvT { get; set; }
        public double AvDP { get; set; }
        public double OneHrP { get; set; }
        public double TPcpn { get; set; }
        public int PDir { get; set; }
        public double AvSp { get; set; }
        public int Dir { get; set; }
        public int MxS { get; set; }
        public double SkyC { get; set; }
        public int MxR { get; set; }
        public int Mn { get; set; }
        public double RAvSLP { get; set; }
    }
}
