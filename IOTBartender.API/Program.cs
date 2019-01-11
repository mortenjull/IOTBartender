using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IOTBartender.Domain.UnitOfWorks;
using IOTBartender.Infrastructure.EFCore;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace IOTBartender.API
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var host = CreateWebHostBuilder(args)
                .Build();

            using (var scope = host.Services.CreateScope())
            {
                var dbContext = scope.
                    ServiceProvider
                    .GetRequiredService<ApplicationDbContext>();

                var unitOfWork = scope
                    .ServiceProvider
                    .GetRequiredService<IUnitOfWork>();

                DatabaseSeed.Seed(dbContext, unitOfWork);
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
