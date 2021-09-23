using FileReader.Application.Common;
using FileReader.Core.Models;
using System.Collections.Generic;

namespace FileReader.Application.Services
{
    public class RainFallService : IRainFallService
    {
        private readonly IRainFallDataRepository repository;
        private readonly IDataTableService dataTableService;

        public RainFallService(
            IRainFallDataRepository repository, 
            IDataTableService dataTableService)
        {
            this.repository = repository;
            this.dataTableService = dataTableService;
        }

        public void SaveData(List<RainFallData> data)
        {
            var dataTable = dataTableService.ConvertListToDataTable(data);

            repository.Insert(dataTable);
        }
    }
}
