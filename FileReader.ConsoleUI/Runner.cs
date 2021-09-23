using FileReader.Application.Services;
using System;

namespace FileReader.ConsoleUI
{
    public class Runner
    {
        private readonly IFileReadService fileReadService;
        private readonly IDataExtractionService dataExtractionService;
        private readonly IRainFallService rainFallService;

        public Runner(IFileReadService fileReadService, IDataExtractionService dataExtractionService, IRainFallService rainFallService)
        {
            this.fileReadService = fileReadService;
            this.dataExtractionService = dataExtractionService;
            this.rainFallService = rainFallService;
        }

        public void Run()
        {
            var array = fileReadService.ReadAllLines(@"C:\temp\cru-ts-2-10.1991-2000-cutdown.pre");
            var data = dataExtractionService.ConvertStringArrayToData(array);
            rainFallService.SaveData(data);

            Console.ReadLine();
        }
    }
}
