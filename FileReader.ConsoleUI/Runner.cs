using FileReader.Application.Services;
using System;
using System.Diagnostics;

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
            var timer = new Stopwatch();
            Guid headerId = new Guid();

            Console.WriteLine("Please enter the path of the file:");
            var path = Console.ReadLine();

            Console.WriteLine("Would you like to save header data?: (Y/N)");
            var header = Console.ReadLine();
            bool saveHeader = false;

            if(header.ToLower() == "y" || header.ToLower() == "yes")
            {
                saveHeader = true;
            }

            timer.Start();
            Console.WriteLine("Reading data from file...");
            var array = fileReadService.ReadAllLines(path);
            timer.Stop();
            var elapsed = timer.ElapsedMilliseconds;
            var seconds = timer.Elapsed.TotalSeconds;
            Console.WriteLine($"Reading data from file... DONE in {elapsed} milliseconds ({seconds} seconds)");

            if (saveHeader)
            {
                timer.Start();
                Console.WriteLine("Converting header data...");
                var headerData = dataExtractionService.ConvertHeader(array);
                headerId = headerData.Id;
                timer.Stop();
                elapsed = timer.ElapsedMilliseconds;
                seconds = timer.Elapsed.TotalSeconds;
                Console.WriteLine($"Converting data...DONE in {elapsed} millisecondss ({seconds} seconds)");

                timer.Start();
                Console.WriteLine("Saving header data to DB...");
                rainFallService.SaveHeader(headerData);
                timer.Stop();
                elapsed = timer.ElapsedMilliseconds;
                seconds = timer.Elapsed.TotalSeconds;
                Console.WriteLine($"Saving data to DB...DONE in {elapsed} millisecondss ({seconds} seconds)");
            }

            timer.Start();
            Console.WriteLine("Converting data...");
            var data = dataExtractionService.ConvertStringArrayToData(array, headerId);

            timer.Stop();
            elapsed = timer.ElapsedMilliseconds;
            seconds = timer.Elapsed.TotalSeconds;
            Console.WriteLine($"Converting data...DONE in {elapsed} millisecondss ({seconds} seconds)");

            timer.Start();
            Console.WriteLine("Saving data to DB...");
            rainFallService.SaveData(data);
            timer.Stop();
            elapsed = timer.ElapsedMilliseconds;
            seconds = timer.Elapsed.TotalSeconds;
            Console.WriteLine($"Saving data to DB...DONE in {elapsed} millisecondss ({seconds} seconds)");

            Console.WriteLine("FINISHED");
        }
    }
}
