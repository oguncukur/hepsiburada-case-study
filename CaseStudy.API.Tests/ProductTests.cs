using CaseStudy.API.Tests.Model;
using CaseStudy.Application.Products.Commands.PostProduct;
using CaseStudy.Application.Products.Commands.UpdateProduct;
using CaseStudy.Application.Products.Queries.GetProduct;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
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

        [Theory, InlineData(new object[] { "61e2ff277334080a30012d24" })]
        public async Task GetAsync_ShouldReturnProduct_WhenTakesId(string id)
        {
            var response = await _client.GetAsync("api/v1/products" + "/" + id);
            var product = JsonConvert.DeserializeObject<ProductDto>(await response.Content.ReadAsStringAsync());
            Assert.IsType<ProductDto>(product);
        }

        [Theory, ClassData(typeof(PostProductTestTheoryData))]
        public async Task PostAsync_ShouldReturnProduct_WhenTakesParameters(PostProductCommand parameter)
        {
            var json = JsonConvert.SerializeObject(parameter);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/v1/products", data);
            var product = JsonConvert.DeserializeObject<ProductDto>(await response.Content.ReadAsStringAsync());
            Assert.IsType<ProductDto>(product);
        }

        [Theory, ClassData(typeof(UpdateProductTestTheoryData))]
        public async Task PutAsync_ShouldReturnProduct_WhenTakesParameters(UpdateProductCommand parameter)
        {
            var json = JsonConvert.SerializeObject(parameter);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("api/v1/products", data);
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Theory, InlineData(new object[] { "61e2ff277334080a30012d24" })]
        public async Task DeleteAsync_ShouldReturnProduct_WhenTakesParameters(string id)
        {
            var response = await _client.DeleteAsync("api/v1/products" + "/" + id);
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }
    }
}