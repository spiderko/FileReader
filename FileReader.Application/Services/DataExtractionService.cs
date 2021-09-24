using FileReader.Core.Extensions;
using FileReader.Core.Models;
using System;
using System.Collections.Generic;

namespace FileReader.Application.Services
{
    public class DataExtractionService : IDataExtractionService
    {
        public List<RainFallData> ConvertStringArrayToData(string[] arr)
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
    }
}
