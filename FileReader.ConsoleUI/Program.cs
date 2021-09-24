using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using FileReader.Application.Services;
using FileReader.Infrastructure.Repositories;
using FileReader.Application.Common;

namespace FileReader.ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();

            host.Services.GetRequiredService<Runner>().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services => 
                {
                    services.AddTransient<Runner>();
                    services.AddScoped<IDataExtractionService, DataExtractionService>();
                    services.AddTransient<IDataTableService, DataTableService>();
                    services.AddTransient<IFileReadService, FileReadService>();
                    services.AddTransient<IRainFallService, RainFallService>();
                    services.AddTransient<IRainFallDataRepository, RainFallDataRepository>();
                    services.AddTransient<IRainFallHeaderRepository, RainFallHeaderRepository>();
                });
        }
    }
}
