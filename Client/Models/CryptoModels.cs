using System.Text.Json.Serialization;

namespace DarraghConway_CA1.Client.Models;

public class CoinMarketCapResponse
{
    [JsonPropertyName("data")]
    public List<CryptoListing> Data { get; set; } = new();
}

public class CryptoListing
{
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
