using System;
namespace M.PAHNEV_SpaceP
{
    public class WeightedDay
    {
        public Day Day { get; private set; }


        //I use "weight" to determine the favourability of the day selected for the launch
        public double Weight { get; private set; } = 0.0;

        public WeightedDay(Day DayToLaunch)
        {
            Day = DayToLaunch;
            CalculateWeight(Day);
        }

        private void CalculateWeight(Day DayForLaunch)
        {
            if (DayForLaunch.Temperature > 32 || DayForLaunch.Temperature < 1
            || DayForLaunch.Precipitation > 0.0 || DayForLaunch.Lightning
            || DayForLaunch.TypeOfCloud == CloudType.Nimbus || DayForLaunch.TypeOfCloud == CloudType.Cumulus
            || DayForLaunch.WindSpeed > 11
            || DayForLaunch.Humidity > 55.0) return;

            Weight += (11 - DayForLaunch.WindSpeed);
            Weight += (55 - DayForLaunch.Humidity) / 5.0;

        }
    }
}

