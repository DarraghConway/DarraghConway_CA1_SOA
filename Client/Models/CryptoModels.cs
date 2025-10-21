using System.Text.Json.Serialization;

namespace DarraghConway_CA1.Client.Models;

public class CoinMarketCapResponse
{
    [JsonPropertyName("data")]
    public List<CryptoListing> Data { get; set; } = new();
}

public class CryptoListing
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("cmc_rank")]
    public int CmcRank { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = string.Empty;

    [JsonPropertyName("quote")]
    public Dictionary<string, QuoteCurrency>? Quote { get; set; }
}

public class QuoteCurrency
{
    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    [JsonPropertyName("percent_change_24h")]
    public decimal PercentChange24h { get; set; }

    [JsonPropertyName("market_cap")]
    public decimal MarketCap { get; set; }
}


public class CryptoPanicResponse
{
    [JsonPropertyName("results")]
    public List<CryptoPanicPost>? Results { get; set; }
}

public class CryptoPanicPost
{
    [JsonPropertyName("title")] public string? Title { get; set; }
    
    [JsonPropertyName("url")] public string? Url { get; set; }
    
    [JsonPropertyName("news_url")] public string? NewsUrl { get; set; }
    
    [JsonPropertyName("source")] public CryptoPanicSource? Source { get; set; }
    
    [JsonPropertyName("id")] public long Id { get; set; }
    [JsonPropertyName("slug")] public string? Slug { get; set; }

    [JsonPropertyName("domain")] public string? Domain { get; set; }
    [JsonPropertyName("published_at")] public DateTime PublishedAt { get; set; }
}

public class CryptoPanicSource
{
    [JsonPropertyName("url")] public string? Url { get; set; }
}