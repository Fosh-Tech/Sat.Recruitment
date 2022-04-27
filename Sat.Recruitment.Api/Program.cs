using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sat.Recruitment.Api.Common;

namespace Sat.Recruitment.Api
{
    public class Program
    {
        public static IocContainer UnityContainer { get; private set; }

        public static void Main(string[] args)
        {
            UnityContainer = new IocContainer();
            UnityContainer.Register();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
