using FileReader.Core.Models;
using System;
using System.Collections.Generic;

namespace FileReader.Application.Services
{
    public interface IDataExtractionService
    {
        List<RainFallData> ConvertStringArrayToData(string[] arr, Guid headerId);
        RainFallHeader ConvertHeader(string[] arr);
    }
}