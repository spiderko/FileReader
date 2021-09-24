using FileReader.Application.Common;
using FileReader.Core.Models;
using System.Collections.Generic;

namespace FileReader.Application.Services
{
    public class RainFallService : IRainFallService
    {
        private readonly IRainFallDataRepository bodyRepository;
        private readonly IRainFallHeaderRepository headerRepository;
        private readonly IDataTableService dataTableService;

        public RainFallService(
            IRainFallDataRepository bodyRepository, 
            IRainFallHeaderRepository headerRepository,
            IDataTableService dataTableService)
        {
            this.bodyRepository = bodyRepository;
            this.headerRepository = headerRepository;
            this.dataTableService = dataTableService;
        }

        public void SaveData(List<RainFallData> data)
        {
            var dataTable = dataTableService.ConvertListToDataTable(data);

            bodyRepository.Insert(dataTable);
        }

        public void SaveHeader(RainFallHeader data)
        {
            headerRepository.Insert(data);
        }
    }
}
