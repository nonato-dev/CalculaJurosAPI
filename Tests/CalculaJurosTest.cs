using Microsoft.AspNetCore.Mvc.Testing;
using System;
using Xunit;
using CalculaJuros.API;
using TaxaJuros.API;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;

namespace Tests
{
    public class CalculaJurosTest 
    {
        private readonly HttpClient _client;

        public CalculaJurosTest()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());
            _client = server.CreateClient();


        }

        [Theory]
        [InlineData("GET")]
        public async Task Test1(string method)
        {
            var request = new HttpRequestMessage(new HttpMethod(method), "/calculaJuros");

            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
