using CaseStudy.Application.Products.Queries.GetProduct;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace CaseStudy.API.Tests
{
    public class ProductTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public ProductTests(WebApplicationFactory<Startup> fixture)
        {
            _client = fixture.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = new Uri("http://localhost:19450") });
        }

        [Fact]
        public async Task Get_ShouldReturnProduct_WhenTakesParameters()
        {
            var id = "61e2ff277334080a30012d24";
            var response = await _client.GetAsync("api/v1/products" + "/" + id);
            var product = JsonConvert.DeserializeObject<ProductDto>(await response.Content.ReadAsStringAsync());
            Assert.IsType<ProductDto>(product);
        }
    }
}
