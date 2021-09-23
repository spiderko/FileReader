using FileReader.Application.Services;
using System;

namespace FileReader.ConsoleUI
{
    public class Runner
    {
        private readonly IFileReadService fileReadService;
        public Runner(IFileReadService fileReadService)
        {
            this.fileReadService = fileReadService;
        }

        public void Run()
        {

        }
    }
}
