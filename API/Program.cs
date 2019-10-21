using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // CreateWebHostBuilder(args).Build().Run();
           var hosts= CreateWebHostBuilder(args).Build();
           using(var scope=hosts.Services.CreateScope()){
               var service=scope.ServiceProvider;
               try{
                    var contex=service.GetRequiredService<Persistance.DataContext>();
                    contex.Database.Migrate();
               }
               catch(Exception ex){
                   var logger=service.GetRequiredService<ILogger<Program>>();
                   logger.LogError(ex,"An error during migration");

               }
               
           }
           hosts.Run();

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
