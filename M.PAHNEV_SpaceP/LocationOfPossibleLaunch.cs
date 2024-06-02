using System;
namespace M.PAHNEV_SpaceP
{
    public class LocationOfPossibleLaunch
    {
        public string Name { get; private set; } = "";

        public double PositionRelativeToEquator { get; set; }

        public WeightedDay BestDayOfLaunch;

        public LocationOfPossibleLaunch(WeightedDay BestDay, string fileName)
        {
            BestDayOfLaunch = BestDay;
            Dictionary<string,double> result = ParseNameFromFile(fileName);

            var firstEntry = result.First();
            Name = firstEntry.Key;
            PositionRelativeToEquator = firstEntry.Value;
        }

        private static Dictionary<string, double> DistancesFromLocationsToEquator = new Dictionary<string, double>()
        {
            { "Kourou", 582.73 },
            { "Cape Canaveral", 3175.36 },
            { "Tanegashima", 3377.21 },
            { "Mahia", 4364.22 },
            { "Kodiak", 6425.4 }
        };
        private static Dictionary<string, double> ParseNameFromFile(string fileName)
        {
            string lowerInput = fileName.ToLower();
            Dictionary<string, double> result = new Dictionary<string, double>();

            foreach (var kvp in DistancesFromLocationsToEquator)
            {
                if (lowerInput.Contains(kvp.Key.ToLower().Replace(" ","")))
                {
                    result.Add(kvp.Key, kvp.Value);
                    break;
                }
            }

            return result;
        }
    }
}

