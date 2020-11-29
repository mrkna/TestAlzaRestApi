using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestAlzaRestApi.Controllers.V2;
using TestAlzaRestApi.Models;
using TestAlzaRestApi.Test.Model;
using Xunit;

namespace TestAlzaRestApi.Test.UnitTests
{
    
    public class ProductControllerUnitTest
    {

        [Fact]
        public async Task TestGetAllProductAsync()
        {
            //Arange
            var dbContext = DbContextMocker.GetProductContext(nameof(TestGetAllProductAsync));
            ProductsController controller = new ProductsController(dbContext);

            //Act
            var response = await controller.GetProductsAsync();
            var value = response.Value as List<Product>;

            //Assert
            dbContext.Dispose();
            Assert.True(value != null);
        }

        [Fact]
        public async Task TestGetProductAsync()
        {
            //Arange
            var dbContext = DbContextMocker.GetProductContext(nameof(TestGetProductAsync));
            ProductsController controller = new ProductsController(dbContext);

            //Act
            var response = await controller.GetProductAsync(1);
            var value = response.Value as Product;

            //Assert
            dbContext.Dispose();
            Assert.True(value != null);
        }

        [Fact]
        public async Task TestPatchtProductAsync()
        {
            //Arange
            var dbContext = DbContextMocker.GetProductContext(nameof(TestPatchtProductAsync));
            ProductsController controller = new ProductsController(dbContext);
            ProductDescription description = new ProductDescription() { Description = "UnitTest" };

            //Act
            var response = await controller.PatchProductAsync(1, description);

            //Assert
            dbContext.Dispose();
            Assert.True(response is NoContentResult);
        }

        [Fact]
        public async Task TestGetMaxProductAsync()
        {
            //Arange
            var dbContext = DbContextMocker.GetProductContext(nameof(TestGetMaxProductAsync));
            ProductsController controller = new ProductsController(dbContext);

            //Act
            var response = await controller.GetProductsPaginationAsync(1);
            var value = response.Value as List<Product>;

            //Assert
            dbContext.Dispose();
            Assert.True(value.Count > 0 && value.Count < 11);
        }
    }
}
