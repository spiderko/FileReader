using FileReader.Application.Services;
using System;

namespace FileReader.ConsoleUI
{
    public class Runner
    {
        private readonly IFileReadService fileReadService;
        private readonly IDataExtractionService dataExtractionService;

        public Runner() : this(
            new FileReadService(), 
            new DataExtractionService())
        {
        }

        public Runner(IFileReadService fileReadService, IDataExtractionService dataExtractionService)
        {
            this.fileReadService = fileReadService;
            this.dataExtractionService = dataExtractionService;
        }

        public void Run()
        {
            var array = fileReadService.ReadAllLines(@"C:\temp\cru-ts-2-10.1991-2000-cutdown.pre");
            var data = dataExtractionService.ConvertStringArrayToData(array);


            Console.ReadLine();
        }
    }
}
