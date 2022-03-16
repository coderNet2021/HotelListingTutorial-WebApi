using Microsoft.EntityFrameworkCore;

namespace HotelListing.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext( DbContextOptions options) : base(options)
        {
        }
        

        public DbSet<Country> Countries{get;set;}
         public DbSet<Hotel> Hotels{get;set;}


         protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<Country>().HasData(
                new Country{
                    Id=1,
                    Name="Jamaica",
                    ShortName="JC"
                },
                new Country{
                    Id=2,
                    Name="Bahamad",
                    ShortName="BM"
                },
                new Country{
                    Id=3,
                    Name="Lebanon",
                    ShortName="LB"
                }
            );

            builder.Entity<Hotel>().HasData(
                new Hotel{
                    Id=1,
                    Name="Jamaica Hotel",
                    Address="address 1",
                    CountryId=1,
                    Rating=4.3
                },
                new Hotel{
                    Id=2,
                    Name="Bahamad Hotel",
                    Address="address 2",
                    CountryId=2,
                    Rating=4.4
                },
                new Hotel{
                    Id=3,
                    Name="Lebanon Hotel",
                   Address="address 3",
                   CountryId=3,
                    Rating=4.5
                }
            );
        }
    }
}