using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Net.Http;
using System.Net;

namespace TestAlzaRestApi.Test.IntegrationTests
{
    public class ProductControllerIntegrationTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        
        public ProductControllerIntegrationTest(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ProductGetAllTestAsync()
        {
            //Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/api/v2/Products");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task ProductGetTestAsync()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/api/v2/Products/2");

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task ProductMaxTestAsync()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/api/v2/Products/page/2");

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task ProductPatchTestAsync()
        {
            // Arrange
            var client = _factory.CreateClient();
            HttpContent content = new StringContent("{\"description\": \"IntegrationTest\"}", Encoding.UTF8, "application/json");

            // Act
            var response = await client.PatchAsync("/api/v2/Products/1", content);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

    }
}
