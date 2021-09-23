using FileReader.Core.Models;
using System.Collections.Generic;

namespace FileReader.Application.Services
{
    public interface IDataExtractionService
    {
        List<RainFallData> ConvertStringArrayToData(string[] arr);
    }
}