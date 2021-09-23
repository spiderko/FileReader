using System;
using System.Collections.Generic;
using System.Text;

namespace FileReader.Application.Services
{
    public class FileReadService : IFileReadService
    {
        public string[] ReadAllLines(string fileLocation)
        {
            if (string.IsNullOrEmpty(fileLocation))
            {
                fileLocation = @"C:\temp\cru-ts-2-10.1991-2000-cutdown.pre";
            }

            return System.IO.File.ReadAllLines(fileLocation);
        }
    }
}
