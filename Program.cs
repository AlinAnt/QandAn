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
                            options.Periodicity = PeriodicityOptions.Hourly;
                        });
                        builder.AddFilter("Microsoft", LogLevel.Error);
                    }).ConfigureAppConfiguration((hostWeb, config) => {
                        config.AddJsonFile("mail.json");
                    })
                    .UseStartup<Startup>();  
    }
}
