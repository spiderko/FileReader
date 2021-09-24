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

            timer.Start();
            Console.WriteLine("Reading data from file...");
            var array = fileReadService.ReadAllLines(@"C:\temp\cru-ts-2-10.1991-2000-cutdown.pre");
            timer.Stop();
            var elapsed = timer.ElapsedMilliseconds;
            var seconds = timer.Elapsed.TotalSeconds;
            Console.WriteLine($"Reading data from file... DONE in {elapsed} milliseconds ({seconds} seconds)");

            timer.Start();
            Console.WriteLine("Converting data...");
            var data = dataExtractionService.ConvertStringArrayToData(array);
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

            Console.ReadLine();
        }
    }
}
