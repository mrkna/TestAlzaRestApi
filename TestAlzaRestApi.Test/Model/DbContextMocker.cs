using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAlzaRestApi.Models;

namespace TestAlzaRestApi.Test.Model
{
    public static class DbContextMocker
    {
        //services.AddDbContext<ProductContext>(opt => DbContextMocker.GetDbContextOptions("MockData"));
        public static ProductContext GetProductContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<ProductContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            var dbContext = new ProductContext(options);

            dbContext.Seed();

            return dbContext;
        }

        public static DbContextOptions<ProductContext> GetDbContextOptions(string dbName)
        {
            var options = new DbContextOptionsBuilder<ProductContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            var dbContext = new ProductContext(options);

            dbContext.Seed();

            return options;
        }

    }
}
