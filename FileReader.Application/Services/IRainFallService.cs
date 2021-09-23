using FileReader.Core.Models;
using System.Collections.Generic;

namespace FileReader.Application.Services
{
    public interface IRainFallService
    {
        void SaveData(List<RainFallData> data);
    }
}