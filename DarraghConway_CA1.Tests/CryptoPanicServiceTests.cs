using System.Text.Json;
using NUnit.Framework;
using DarraghConway_CA1.Client.Models;

namespace DarraghConway_CA1.Tests;

public class CryptoPanicServiceTests
{
    [Test]
    public void CryptoPanicResponse_Deserializes_Correctly()
    {
        var json = """
                   {
                     "results": [
                       {
                         "title": "Bitcoin price surges to new highs",
                         "url": "https://example.com/bitcoin-news",
                         "published_at": "2024-10-10T12:00:00Z"
                       },
                       {
                         "title": "Ethereum shows strong growth",
                         "url": "https://example.com/eth-news",
                         "published_at": "2024-10-09T10:30:00Z"
                       }
                     ]
                   }
                   """;
        
        var result = JsonSerializer.Deserialize<CryptoPanicResponse>(json,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        
        Assert.That(result, Is.Not.Null);
        Assert.That(result!.Results, Is.Not.Null);
        Assert.That(result.Results!.Count, Is.EqualTo(2));

        Assert.That(result.Results[0].Title, Does.Contain("Bitcoin"));
        Assert.That(result.Results[0].Url, Does.Contain("bitcoin-news"));
        
        Assert.That(result.Results[1].Title, Does.Contain("Ethereum"));
        Assert.That(result.Results[1].Url, Does.Contain("eth-news"));
    }
}