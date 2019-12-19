using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NetEscapades.Extensions.Logging.RollingFile;


namespace QandAn
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .ConfigureLogging((hostingContext, builder) =>
                    {
                        builder.AddFile(options => {
                            options.FileName = "logFile-";
                            options.LogDirectory = "Logs";
                            options.FileSizeLimit = 20 * 1024 * 1024; // 20 MB
                            options.Extension = "txt"; 
                            options.Periodicity = PeriodicityOptions.Hourly;
                        });
                        builder.AddFilter("Microsoft", LogLevel.Error);
                    }) 
                    .UseStartup<Startup>();  
    }
}
