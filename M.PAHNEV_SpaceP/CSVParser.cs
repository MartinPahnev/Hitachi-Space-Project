using System;
using System.Data;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace M.PAHNEV_SpaceP
{
    public class CSVParser
    {  
        private static DataTable ReadCSVFile(string fileName)
        {
            DataTable weatherDataTable = new DataTable();

            using (var reader = new StreamReader(fileName))
            {
                var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = false
                };

                using (var csv = new CsvReader(reader, csvConfig))
                {
                    using (var dtReader = new CsvDataReader(csv))
                    {
                        weatherDataTable.Load(dtReader);
                    }
                }
            }

            return weatherDataTable;
        }

        public static LocationOfPossibleLaunch ParseLocation(string FileName)
        {
            
            DataTable report = ReadCSVFile(FileName);
            report = TransposeDataTable(report);

            List<WeightedDay> DaysList = ParseTable(report);

            LocationOfPossibleLaunch location = new LocationOfPossibleLaunch(GetBestDay(DaysList),FileName);

            return location;
        }


        private static DataTable TransposeDataTable(DataTable inputTable)
        {
            DataTable outputTable = new DataTable();

            foreach (DataRow row in inputTable.Rows)
            {
                outputTable.Columns.Add(row[0].ToString()?.Trim());
            }

            for (int colIndex = 1; colIndex < inputTable.Columns.Count; colIndex++) 
            {
                DataRow newRow = outputTable.NewRow();
                newRow[outputTable.Columns.Count - 1] = inputTable.Columns[colIndex].ColumnName;

                for (int rowIndex = 0; rowIndex < inputTable.Rows.Count; rowIndex++)
                {
                    newRow[rowIndex] = inputTable.Rows[rowIndex][colIndex];
                }
                outputTable.Rows.Add(newRow);
            }

            return outputTable;
        }


        private static List<WeightedDay> ParseTable(DataTable WeatherReportData)
        {
            List<WeightedDay> ParsedData = new List<WeightedDay>();

            foreach (DataRow row in WeatherReportData.Rows)
            {
                uint dayParameter = Convert.ToUInt32(row[Constants.DayString]);
                int temperature = Convert.ToInt32(row[Constants.TemperatureString]);
                int wind = Convert.ToInt32(row[Constants.WindString]);
                double humidity = Convert.ToDouble(row[Constants.HumidityString]);
                double precipitation = Convert.ToDouble(row[Constants.PrecipitationString]);
                bool lightning = row[Constants.LightningString].ToString()?.ToLower() == Constants.YesConstant;
                CloudType clouds = Enum.Parse<CloudType>(row[Constants.CloudString].ToString()!);

                Day day = new Day(dayParameter, temperature, wind, humidity, precipitation, lightning, clouds);
                ParsedData.Add(new WeightedDay(day));
            }
            return ParsedData;
        }


        private static WeightedDay GetBestDay(List<WeightedDay> ListOfPossibleDaysForLaunch)
        {
            return ListOfPossibleDaysForLaunch.MaxBy(x => x.Weight)!;
        }
    }
}