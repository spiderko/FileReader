using System.Collections.Generic;
using System.Data;

namespace FileReader.Application.Services
{
    public interface IDataTableService
    {
        DataTable ConvertListToDataTable<T>(List<T> list);
    }
}