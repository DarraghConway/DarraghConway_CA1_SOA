using System.Net;
using System.Net.Http;
using DarraghConway_CA1.Client.Models;
using DarraghConway_CA1.Client.Services;
using FluentAssertions;
using NUnit.Framework;

namespace DarraghConway_CA1.Tests
{
    public class CoinMarketCapServiceTests
    {
        [Test]
        public async Task GetLatestAsync_ReturnsParsedData()
        {
            var json = """
                       {
                         "data": [
                           {
                             "id": 1,
                             "cmc_rank": 1,
                             "name": "Bitcoin",
                             "symbol": "BTC",
                             "quote": { "USD": { "price": 68000, "percent_change_24h": 1.25, "market_cap": 900000000000 } }
                           }
                         ]
                       }
                       """;

            var handler = new StubHandler(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(json)
            });

            var http = new HttpClient(handler);
            var service = new CoinMarketCapService(http);
            
            var result = await service.GetLatestAsync(20);
            
            result.Should().HaveCount(1);
            result[0].Name.Should().Be("Bitcoin");
            result[0].Symbol.Should().Be("BTC");
            result[0].Quote.Should().ContainKey("USD");
            result[0].Quote!["USD"].Price.Should().Be(68000);
        }

        private sealed class StubHandler : HttpMessageHandler
        {
            private readonly HttpResponseMessage _response;
            public StubHandler(HttpResponseMessage response) => _response = response;
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct)
                => Task.FromResult(_response);
        }
    }
}