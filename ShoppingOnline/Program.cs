using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Shopping_online.Models;
using ShoppingOnline.DBContext;
using ShoppingOnline.Models;
using ShoppingOnline.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Services.Store;

namespace ShoppingOnline
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var LoggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var context = services.GetRequiredService<StoreContextDBContext>();
                    await context.Database.MigrateAsync();
                    await StoreContextSeedcs.SeedAsync(context, LoggerFactory);


                    //var UserManager = services.GetRequiredService<UserManager<AppUser>>;
                    //var IdentityContext = services.GetRequiredService<AppIdentityDBContext>;

                    //var UserManager = services.GetRequiredService<UserManager<AppUser>>;
                    //var IdentityDbContext = services.GetRequiredService<AppIdentityDBContext>();


                    //await IdentityDbContext.Database.MigrateAsync();
                    //await AddUserIdentityDBContextSeed.SeedUserAsync(UserManager);


                }
                catch (Exception ex)
                {
                    var Logger = LoggerFactory.CreateLogger<Program>();
                    Logger.LogError(ex, "An error occured during migration");

                }
            }

            host.Run();


        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
