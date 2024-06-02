using System;
namespace M.PAHNEV_SpaceP
{
    public enum CloudType
    {
        Nimbus = 0,
        Cumulus,
        Stratus,
        Cirrus
    }

    public class Day
    {
        public uint Date { get; set; }
        public int Temperature { get; set; }
        public int WindSpeed { get; set; }
        public double Humidity { get; set; }
        public double Precipitation { get; set; }
        public bool Lightning { get; set; }
        public CloudType TypeOfCloud { get; set; }

        public Day(uint dayParameter, int temperature, int wind, double humidity, double precipitation, bool lightning, CloudType clouds)
        {
            Date = dayParameter;
            Temperature = temperature;
            WindSpeed = wind;
            Humidity = humidity;
            Precipitation = precipitation;
            Lightning = lightning;
            TypeOfCloud = clouds;
        }

    }
}

