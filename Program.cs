using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelListing.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HotelListing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        
        // private static void SetupDatabase()
        // {
        //     using (var db = new DatabaseContext())
        //     {
        //         if (db.Database.EnsureCreated())
        //         {
        //             #region View
        //         db.Database.ExecuteSqlRaw(
        //             @"CREATE VIEW View_HotelCountries AS
        //                     SELECT b.Name, Count(p.PostId) as PostCount
        //                     FROM Blogs b
        //                     JOIN Posts p on p.BlogId = b.BlogId
        //                     GROUP BY b.Name");
        //         #endregion
        //         }
        //     }
        // }

    }
}
