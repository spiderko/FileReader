using FileReader.Core.Extensions;
using FileReader.Core.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace FileReader.Application.Services
{
    public class DataExtractionService : IDataExtractionService
    {
        public List<RainFallData> ConvertStringArrayToData(string[] arr, Guid headerId)
        {
            var result = new List<RainFallData>();

            var years = GetStartEndYears(arr);
            var startYear = int.Parse(years[0]);
            var endYear = int.Parse(years[1]);

            var range = endYear - startYear;
            var startingRow = GetStartingRow(arr);
            
            var grids = GetGrids(arr);

            foreach (var grid in grids)
            {
                var newGrid = grid;
                var newStartingRow = startingRow;
                var newYear = startYear;

                for (int i = newStartingRow; i <= newStartingRow + range; i++)
                {
                    var columns = arr[i].Split().RemoveEmpties();

                    var month = 1;
                    foreach (var column in columns)
                    {

                        result.Add(
                            new RainFallData(
                                headerId,
                                grid.Item1, 
                                grid.Item2, 
                                new DateTime(newYear, month, 1), 
                                1,
                                month,
                                newYear,
                                int.Parse(column)
                                )
                            );

                        month++;
                    }
                    newYear++;
                }
                
                startingRow = newStartingRow + range + 2;
            }

            return result;
        }

        private string[] GetStartEndYears(string[] arr)
        {
            string[] years = new string[2];

            foreach (var item in arr)
            {
                if (!item.Contains("[Years="))
                {
                    continue;
                }

                var startIndex = item.IndexOf("[Years=") + 7;
                var endIndex = item.Substring(startIndex).IndexOf("]");
                years = item.Substring(startIndex, endIndex).Split("-");

                break;
            }

            return years;
        }

        private List<Tuple<int, int>> GetGrids(string[] arr)
        {
            var grids = new List<Tuple<int, int>>();

            foreach (var item in arr)
            {
                if (!item.Contains("Grid-ref="))
                {
                    continue;
                }
                var gridLess = item.Replace("Grid-ref=", "");
                var trimmedItem = gridLess.Trim();
                var splited = trimmedItem.Split(", ");
                grids.Add(new Tuple<int, int>(int.Parse(splited[0]), int.Parse(splited[1])));
            }

            return grids;
        }

        private int GetStartingRow(string[] arr)
        {
            int startingRow = 0;

            foreach (var item in arr)
            {
                if (!item.Contains("Grid-ref="))
                {
                    startingRow++;
                    continue;
                }


                break;
            }

            return startingRow + 1;
        }

        public RainFallHeader ConvertHeader(string[] arr)
        {
            var title = GetHeaderTitle(arr);
            var dateOn = GetHeaderDateOn(arr);
            var createdBy = GetHeaderCreatedBy(arr);
            var type = GetHeaderType(arr);
            var climaticResearchUnitVersion = GetClimaticResearchUnitVersion(arr);
            var longitudeMin = GetLongitudeMin(arr);
            var longitudeMax = GetLongitudeMax(arr);
            var latitudeMin = GetLatitudeMin(arr);
            var latitudeMax = GetLatitudeMax(arr);
            var gridX = GetGridX(arr);
            var gridY = GetGridY(arr);
            var boxes = GetBoxes(arr);
            var years = GetStartEndYears(arr);
            var multi = GetMulti(arr);
            var missing = GetMissing(arr);

            var result = new RainFallHeader(
                title,
                type,
                climaticResearchUnitVersion,
                createdBy,
                dateOn,
                longitudeMin,
                longitudeMax,
                latitudeMin,
                latitudeMax,
                gridX,
                gridY,
                boxes,
                int.Parse(years[0]),
                int.Parse(years[1]),
                multi,
                missing);

            return result;
        }

        private string GetHeaderTitle(string[] arr)
        {
            var firstLine = arr.FirstOrDefault();
            var result = firstLine.Substring(0, firstLine.IndexOf(" grim file"));

            return result;
        }

        private DateTime GetHeaderDateOn(string[] arr)
        {
            var firstLine = arr.FirstOrDefault();
            var dateTimeString = firstLine.Substring(firstLine.IndexOf(" created on ") + 12, 19);
            var result = DateTime.ParseExact(dateTimeString.Replace(" at", ""), "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);

            return result;
        }

        private string GetHeaderCreatedBy(string[] arr)
        {
            var firstLine = arr.FirstOrDefault();
            var result = firstLine.Substring(firstLine.IndexOf(" by ")).Replace(" by ", "").Trim();

            return result;
        }

        private string GetHeaderType(string[] arr)
        {
            var firstLine = arr[1];
            var result = firstLine.Substring(firstLine.IndexOf("= ")).Replace("= ", "").Trim();

            return result;
        }

        // GetClimaticResearchUnitVersion
        private string GetClimaticResearchUnitVersion(string[] arr)
        {
            var firstLine = arr[2];
            var result = firstLine.Substring(firstLine.IndexOf("CRU TS ")).Replace("CRU TS ", "").Trim();

            return result;
        }

        private decimal GetLongitudeMin(string[] arr)
        {
            var firstLine = arr[3];
            var stage1 = firstLine.Substring(firstLine.IndexOf("[Long="), 20).Replace("[Long=", "").Trim();
            var result = stage1.Substring(0 , stage1.IndexOf(","));

            return decimal.Parse(result);
        }

        private decimal GetLongitudeMax(string[] arr)
        {
            var firstLine = arr[3];
            var stage1 = firstLine.Substring(firstLine.IndexOf("[Long="), 22).Replace("[Long=", "").Trim();
            var result = stage1.Substring(stage1.IndexOf(",") + 1, 7).Trim();

            return decimal.Parse(result);
        }

        private decimal GetLatitudeMin(string[] arr)
        {
            var firstLine = arr[3];
            var stage1 = firstLine.Substring(firstLine.IndexOf("[Lati="), 20).Replace("[Lati=", "").Trim();
            var result = stage1.Substring(0, stage1.IndexOf(","));

            return decimal.Parse(result);
        }

        private decimal GetLatitudeMax(string[] arr)
        {
            var firstLine = arr[3];
            var stage1 = firstLine.Substring(firstLine.IndexOf("[Lati="), 22).Replace("[Lati=", "").Trim();
            var result = stage1.Substring(stage1.IndexOf(",") + 1, 7).Trim();

            return decimal.Parse(result);
        }

        private int GetGridX(string[] arr)
        {
            var firstLine = arr[3];
            var stage1 = firstLine.Substring(firstLine.IndexOf("[Grid X,Y=")).Replace("[Grid X,Y= ", "").Trim();
            var result = stage1.Substring(0, stage1.IndexOf(","));

            return int.Parse(result);
        }

        private int GetGridY(string[] arr)
        {
            var firstLine = arr[3];
            var stage1 = firstLine.Substring(firstLine.IndexOf("[Grid X,Y=")).Replace("[Grid X,Y= ", "").Trim();
            var result = stage1.Substring(stage1.IndexOf(",")).Replace(",", "").Replace("]", "").Trim();

            return int.Parse(result);
        }

        private int GetBoxes(string[] arr)
        {
            var firstLine = arr[4];
            var stage1 = firstLine.Substring(firstLine.IndexOf("[Boxes=")).Replace("[Boxes= ", "").Trim();
            var result = stage1.Substring(0, stage1.IndexOf("]")).Trim();

            return int.Parse(result);
        }

        private decimal GetMulti(string[] arr)
        {
            var firstLine = arr[4];
            var stage1 = firstLine.Substring(firstLine.IndexOf("[Multi=")).Replace("[Multi= ", "").Trim();
            var result = stage1.Substring(0, stage1.IndexOf("]"));

            return decimal.Parse(result);
        }

        private int GetMissing(string[] arr)
        {
            var firstLine = arr[4];
            var result = firstLine.Substring(firstLine.IndexOf("[Missing=")).Replace("[Missing=", "").Trim().Replace("]", "");

            return int.Parse(result);
        }
    }
}
