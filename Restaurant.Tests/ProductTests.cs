using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using OA_Repository;
using OA_Service;
using RestaurantProject.Controllers;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Restaurant.Tests
{
    public class ProductTests
    {
        [Fact]
        public void Test1()
        {
            Assert.True(1 == 1);
        }

        [Fact]
        public async Task ProductIntegrationTest()
        {
            // Create DB Context
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder
                .UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);

            var context= new ApplicationDbContext(optionsBuilder.Options);

            // Just to make sure: Delete all existing products in the DB
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            // Create Controller
            var controller = new ProductTestController(context);

            // Add product
            await controller.Add(new OA_DataAccess.Product() { Name = "SmartPhone", Details = "Nokia", StockAvailable = 100 });

            // Check: Does GetAll return the added product?
            var result = (await controller.GetAll()).ToArray() ;
            Assert.Single(result);
            Assert.Equal("SmartPhone", result[0].Name);
        }
    }
}
